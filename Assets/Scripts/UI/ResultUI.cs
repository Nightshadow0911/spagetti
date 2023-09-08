using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultUI : MonoBehaviour
{
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private Button retryButton;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button nextStageButton;
    [SerializeField] private GameObject resultObj;

    [SerializeField] private float scoreIncreasingTime = 2f;

    void Start()
    {
        // TODO : 씬 매니저로 옮겨서 등록
        // 다시하기
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //retryButton.onClick.AddListener()
        //mainMenuButton.onClick.AddListener();
        //nextStageButton.onClick.AddListener();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        UIManager.Instance.OnGameEnded += ShowEndUI;
        resultObj.SetActive(false);
    }

    private void ShowEndUI(bool isClear)
    {
        // 플레이어 네임 표시
        nameText.text = GameManager.Instance.PlayerName;
        // Score
        StartCoroutine(CoShowIncreasingEffect(scoreText, GameManager.Instance.Score));
        // HighScore
        StartCoroutine(CoShowIncreasingEffect(highScoreText, GameManager.Instance.HighScore));

        nextStageButton.gameObject.SetActive(isClear);
    }

    private IEnumerator CoShowIncreasingEffect(TMP_Text text, int score)
    {
        float ratio = 0f;
        
        while (ratio < 1)
        {
            ratio += Time.deltaTime / scoreIncreasingTime;
            ratio = Mathf.Clamp01(ratio);
            text.text = ((int)Mathf.Lerp(ratio * score, score, ratio)).ToString();
            yield return null;
        }
    }

}
