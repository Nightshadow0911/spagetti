using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject nameInputUI;
    public InputField nameInputField;

    private void Start()
    {
        nameInputUI.SetActive(false);
        LoadPlayerName(); // 게임 시작 시 저장된 이름을 불러옵니다.
    }

    public void OnNameInputButtonClicked()
    {
        nameInputUI.SetActive(true);
    }

    public void OnNameSubmitButtonClicked()
    {
        string playerName = nameInputField.text;

        // PlayerPrefs를 사용하여 이름 저장
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.Save(); // 변경 사항 저장

        // 여기에서 playerName을 사용하여 원하는 작업을 수행할 수 있습니다.

        // 이름 입력 UI를 다시 비활성화합니다.
        nameInputUI.SetActive(false);
    }

    private void LoadPlayerName()
    {
        // PlayerPrefs에서 저장된 이름을 불러옵니다.
        string savedName = PlayerPrefs.GetString("PlayerName", "");

        // 저장된 이름이 있는 경우 입력 필드에 표시합니다.
        if (!string.IsNullOrEmpty(savedName))
        {
            nameInputField.text = savedName;
            
        }
    }
}