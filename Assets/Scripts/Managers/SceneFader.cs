using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum SceneType
{
    StartScene,
    Stage1,
    CreditScene,
}

public class SceneFader : MonoBehaviour
{
    private static SceneFader _instance;
    public static SceneFader Instance { get => _instance; }

    public Image fadeImage;
    public float fadeSpeed = 1.0f;

    private bool isFadingOut = false;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeToScene(int sceneIndex)
    {
        StartCoroutine(FadeOut(sceneIndex));
    }

    public SceneType GetCurrentSceneType()
    {
        return (SceneType)SceneManager.GetActiveScene().buildIndex;
    }

    public void ChangeToNextScene()
    {
        //string nextSceneName = "다음 씬의 이름"; // 다음 씬의 이름으로 바꿔야 합니다.
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        FadeToScene(nextSceneIndex);
    }

    IEnumerator FadeIn()
    {
        float alpha = 1.0f;
        while (alpha > 0)
        {
            alpha -= Time.unscaledDeltaTime * fadeSpeed;
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        OnLoadSceneByIndex(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator FadeOut(int sceneIndex)
    {
        if (isFadingOut)
            yield break;

        isFadingOut = true;

        float alpha = 0.0f;
        while (alpha < 1)
        {
            alpha += Time.unscaledDeltaTime * fadeSpeed;
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        SceneManager.LoadScene(sceneIndex);

        StartCoroutine(FadeIn());
    }

    private void OnLoadSceneByIndex(int sceneIndex)
    {
        switch ((SceneType)sceneIndex)
        {
            case SceneType.StartScene:
                SoundManager.Instance.PlayBGM(BGM.MainMenu);
                break;
            case SceneType.Stage1:
                SoundManager.Instance.PlayBGM(BGM.InGame);
                break;
            case SceneType.CreditScene:
                SoundManager.Instance.PlayBGM(BGM.Credit);
                break;
        }
    }
}
