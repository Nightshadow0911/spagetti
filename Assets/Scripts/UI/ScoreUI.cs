using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TMP_Text playerNameText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highScoreText;

    private void Start()
    {
        UIManager.Instance.OnNameChanged += ChangeNameText;
        UIManager.Instance.OnScoreChanged += ChangeScoreText;
        UIManager.Instance.OnHighScoreChanged += ChangeHighScoreText;
    }

    public void ChangeNameText(string name)
    {
        // PlayerPrefs로 정보 넘기기
        playerNameText.text = name;
    }

    public void ChangeScoreText(int score)
    {
        scoreText.text = score.ToString();
    }

    public void ChangeHighScoreText(int highScore)
    {
        highScoreText.text = highScore.ToString();
    }
}
