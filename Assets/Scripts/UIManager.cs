using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject nameInputUI;
    public InputField nameInputField;

    private void Start()
    {
        nameInputUI.SetActive(false);
        LoadPlayerName(); // ���� ���� �� ����� �̸��� �ҷ��ɴϴ�.
    }

    public void OnNameInputButtonClicked()
    {
        nameInputUI.SetActive(true);
    }

    public void OnNameSubmitButtonClicked()
    {
        string playerName = nameInputField.text;

        // PlayerPrefs�� ����Ͽ� �̸� ����
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.Save(); // ���� ���� ����

        // ���⿡�� playerName�� ����Ͽ� ���ϴ� �۾��� ������ �� �ֽ��ϴ�.

        // �̸� �Է� UI�� �ٽ� ��Ȱ��ȭ�մϴ�.
        nameInputUI.SetActive(false);
    }

    private void LoadPlayerName()
    {
        // PlayerPrefs���� ����� �̸��� �ҷ��ɴϴ�.
        string savedName = PlayerPrefs.GetString("PlayerName", "");

        // ����� �̸��� �ִ� ��� �Է� �ʵ忡 ǥ���մϴ�.
        if (!string.IsNullOrEmpty(savedName))
        {
            nameInputField.text = savedName;
            
        }
    }
}