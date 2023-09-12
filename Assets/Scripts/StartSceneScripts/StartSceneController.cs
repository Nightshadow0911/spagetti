using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class StartSceneController : MonoBehaviour
{
    public GameObject nameInputUI;
    public TMP_InputField nameInputField;
    public Button nameButton; 
    public Button startButton; 
    public GameObject difficultyPanel; 
    public Button difficultyButton; // 난이도 선택 버튼
    

    private bool difficultyPanelVisible = false;

    private void Start()
    {       
        difficultyPanel.SetActive(false);

        difficultyButton.onClick.AddListener(ToggleDifficultyPanel);
        
        nameInputUI.SetActive(false);

        nameButton.onClick.AddListener(ShowNameInputUI);      
        startButton.onClick.AddListener(StartGame);
        
    }
    private void ToggleDifficultyPanel()
    {
        
        difficultyPanelVisible = !difficultyPanelVisible;
        difficultyPanel.SetActive(difficultyPanelVisible);
    }
    private void ShowNameInputUI()
    {
        
        nameInputUI.SetActive(true);
    }

    private void StartGame()
    {
        string playerName = nameInputField.text;

        
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.Save(); 
       
    }
    public void ChangeToNextScene()
    {
        //string nextSceneName = "다음 씬의 이름"; // 다음 씬의 이름으로 바꿔야 합니다.
        string nextSceneName = "GameManagerScene";
        FindObjectOfType<SceneFader>().FadeToScene(nextSceneName);
    }
}