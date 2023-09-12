using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get => _instance; }

    public int Score { get; private set; }
    public int HighScore { get; private set; }
    public int MaxLifeBarCount { get; private set; } = 4;
    [field: SerializeField]
    public int Life { get; private set; } = 2;
    public string PlayerName { get; private set; }

    private const string HIGH_SCORE = "HighScore";

    public GameObject Brick;

    public int rows = 5; // ���� ��, ����

    public int columns = 14; // ���� ��, ����

    public float xbrickSpacing = 1.2f; // ���� ���� ����

    public float ybrickSpacing = 0.5f; // ���� ���� ����


    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        Init();
        MakeBricks();
    }
    public void MakeBricks()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                float x = j * xbrickSpacing;
                float y = i * ybrickSpacing;
                Vector3 brickPosition = new Vector3(x - 7.8f, y + 2.0f, 0);

                GameObject brick = Instantiate(Brick, transform.position + brickPosition, Quaternion.identity);
                BrickControl brickControl = brick.GetComponent<BrickControl>();

                if (brickControl != null)
                {
                    brickControl.InitializeBrick(brickPosition); // ������ ��ġ�� �����Ͽ� �ʱ�ȭ
                }
            }
        }
    }

    private void Init()
    {
        SetPlayerName();

    }


    // ���� ������ �� ����
    public void AddScore(int score)
    {
        Score += score;
        // ScoreUI ����
        UIManager.Instance.CallScoreChanged(Score);

        if (HighScore > score)
        {
            SetHighScore(Score);
            UIManager.Instance.CallHighScoreChanged(Score);
        }
    }

    private void SetHighScore(int score)
    {
        HighScore = score;
        PlayerPrefs.SetInt(HIGH_SCORE, score);
    }

    // �÷��̾� �� ���ο� ���� ������ ���� ���� ����
    public void DecreaseLife()
    {
        Life--;

        if (Life <= 0)
        {
            GameOver();
            return;
        }

        UIManager.Instance.CallLifeChanged(false);
        Reset();
    }

    // ��� ���� ������ �Ծ��� �� ����
    public void IncreaseLife()
    {
        if (Life >= MaxLifeBarCount)
        {
            return;
        }

        Life++;
        UIManager.Instance.CallLifeChanged(true);
    }
    
    public void SetPlayerName()
    {
        PlayerName = PlayerPrefs.GetString("PlayerName");
        UIManager.Instance.CallNameChanged(name);
    }

    // ������ �� ������ �� ����
    public void GameClear()
    {
        UIManager.Instance.CallGameEnded(true);
    }

    private void Reset()
    {
        // �ٽ� �� ��ġ�� �� �̵��� �� ����
        // transform parent �ű�� transfrom.position ������ ��ġ�� �ʱ�ȭ
    }

    private void GameOver()
    {
        // ���� ����
        UIManager.Instance.CallGameEnded(false);
    }
}
