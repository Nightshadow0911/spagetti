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


    [field : SerializeField]
    public int MaxLifeBarCount { get; private set; } = 4;
    [field: SerializeField]
    public int Life { get; private set; } = 2;
    public Action OnResetCallback;

    public string PlayerName { get; private set; }

    private const string HIGH_SCORE = "HighScore";

    public GameObject Brick;

    public int rows = 5; // 벽돌 행, 세로

    public int columns = 14; // 벽돌 열, 가로

    public float xbrickSpacing = 1.2f; // 가로 벽돌 간격

    public float ybrickSpacing = 0.5f; // 세로 벽돌 간격


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
                Vector3 brickPosition = new Vector3(x - 7.8f, y + 1.0f, 0);

                GameObject brick = Instantiate(Brick, transform.position + brickPosition, Quaternion.identity);
                BrickControl brickControl = brick.GetComponent<BrickControl>();

                if (brickControl != null)
                {
                    brickControl.InitializeBrick(brickPosition); // 벽돌의 위치를 전달하여 초기화
                }
            }
        }
    }

    private void Init()
    {
        SetPlayerName();

    }


    // 벽돌 깨졌을 때 연동
    public void AddScore(int score)
    {
        Score += score;
        // ScoreUI 연동
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

    // 플레이어 바 라인에 공이 닿으면 생명 감소 연동
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

    // 목숨 증가 아이템 먹었을 때 연동
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

    // 벽돌이 다 깨졌을 때 연동
    public void GameClear()
    {
        UIManager.Instance.CallGameEnded(true);
    }

    private void Reset()
    {
        OnResetCallback?.Invoke();
    }

    private void GameOver()
    {
        // 게임 종료
        UIManager.Instance.CallGameEnded(false);
    }
}
