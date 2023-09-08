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

    [field: SerializeField]
    public int MaxLifeBarCount { get; private set; } = 4;
    [field: SerializeField]
    public int Life { get; private set; } = 2;

    public string PlayerName { get; private set; }

    private const string HIGH_SCORE = "HighScore";


    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        if (PlayerPrefs.HasKey(HIGH_SCORE))
        {
            SetHighScore(PlayerPrefs.GetInt(HIGH_SCORE));
        }
    }

    public void AddScore(int score)
    {
        Score += score;
        // ScoreUI ����
        UIManager.Instance.CallScoreChanged(Score);

        if (HighScore > score)
        {
            SetHighScore(Score);
        }
    }

    private void SetHighScore(int score)
    {
        HighScore = score;
        PlayerPrefs.SetInt(HIGH_SCORE, score);
    }

    // �÷��̾� �� ���ο� ���� ������ ���� ����
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

    // ��� ���� ������ �Ծ��� ��
    public void IncreaseLife()
    {
        if (Life >= MaxLifeBarCount)
        {
            return;
        }

        Life++;
        UIManager.Instance.CallLifeChanged(true);
    }
    
    public void SetPlayerName(string name)
    {
        PlayerName = name;
        UIManager.Instance.CallNameChanged(name);
    }

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