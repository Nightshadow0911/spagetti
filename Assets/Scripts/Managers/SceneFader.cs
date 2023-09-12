using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum SceneType
{
    StartScene,
    Juchan_MainSceneClone,
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

    public void ChangeToNextScene()
    {
        //string nextSceneName = "¥Ÿ¿Ω æ¿¿« ¿Ã∏ß"; // ¥Ÿ¿Ω æ¿¿« ¿Ã∏ß¿∏∑Œ πŸ≤„æﬂ «’¥œ¥Ÿ.
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        FindObjectOfType<SceneFader>().FadeToScene(nextSceneIndex);
    }

    IEnumerator FadeIn()
    {
        float alpha = 1.0f;
        while (alpha > 0)
        {
            alpha -= Time.deltaTime * fadeSpeed;
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
            alpha += Time.deltaTime * fadeSpeed;
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        var async = SceneManager.LoadSceneAsync(sceneIndex);

        while (!async.isDone)
        {
            yield return null;
        }

        OnLoadSceneByIndex(sceneIndex);
    }

    private void OnLoadSceneByIndex(int sceneIndex)
    {
        switch ((SceneType)sceneIndex)
        {
            case SceneType.StartScene:
                SoundManager.Instance.PlayBGM(BGM.MainMenu);
                break;
            case SceneType.Juchan_MainSceneClone:
                SoundManager.Instance.PlayBGM(BGM.InGame);
                break;
            case SceneType.CreditScene:
                // ≈©∑πµ˜ ¿Ωæ«
                break;
        }
    }
}
