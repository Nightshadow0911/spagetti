using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
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
        SetPlayerName();
        Time.timeScale = 1.0f;
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

        UIManager.Instance.CallLifeChanged(false);

        if (Life <= 0)
        {
            GameOver();
            return;
        }
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
        Time.timeScale = 0;
    }

    private void GameOver()
    {
        // 게임 종료
        UIManager.Instance.CallGameEnded(false);
        Time.timeScale = 0;
    }
}
