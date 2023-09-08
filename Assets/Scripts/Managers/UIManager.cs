using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance { get => _instance; }

    public event Action<bool> OnLifeChanged;
    public event Action<bool> OnGameEnded;
    public event Action<int> OnScoreChanged;
    public event Action<int> OnHighScoreChanged;
    public event Action<string> OnNameChanged;

    private void Awake()
    {
        _instance = this;
    }
    
    public void CallLifeChanged(bool isIncrease)
    {
        OnLifeChanged?.Invoke(isIncrease);
    }

    public void CallScoreChanged(int score)
    {
        OnScoreChanged?.Invoke(score);
    }

    public void CallHighScoreChanged(int highScore)
    {
        OnHighScoreChanged?.Invoke(highScore);
    }

    public void CallNameChanged(string name)
    {
        OnNameChanged?.Invoke(name);
    }

    public void CallGameEnded(bool isClear)
    { 
        OnGameEnded?.Invoke(isClear);
    }

}
