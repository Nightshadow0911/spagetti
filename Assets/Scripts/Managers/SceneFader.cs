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
        _instance = this;
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
        //string nextSceneName = "다음 씬의 이름"; // 다음 씬의 이름으로 바꿔야 합니다.
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

        SceneManager.LoadScene(sceneIndex);
    }


}
