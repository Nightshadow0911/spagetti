using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionController : MonoBehaviour
{
    [SerializeField] private GameObject resolutionObj;

    private GameObject _resolutionInstance;

    private Slider testSlider;
    private void Awake()
    {
        testSlider = GetComponentInChildren<Slider>();
        testSlider.onValueChanged.AddListener(CreateRT);
        /*Button[] resolutionButtons = GetComponentsInChildren<Button>();
        foreach (Button button in resolutionButtons)
        {
            button.onClick.AddListener(() => CreateRT(float.Parse(button.GetComponentInChildren<TMP_Text>().text)));
        }*/
    }

    private void OnDisable()
    {
        if (_resolutionInstance != null)
        {
            Destroy(_resolutionInstance);
        }
    }

    private void CreateRT(float ratio)
    {
        if (ratio < 0.1f)
        {
            ratio = 0.1f;
        }

        int x = (int)(Screen.width * ratio);
        int y = (int)(Screen.height * ratio);

        var rt = new RenderTexture(x, y, 24, UnityEngine.Experimental.Rendering.DefaultFormat.LDR);

        rt.Create();

        Camera.main.targetTexture = rt;
        RawImage raw = null;

        if (_resolutionInstance == null)
        {
            _resolutionInstance = Instantiate(resolutionObj);
        }
        
        raw = _resolutionInstance.GetComponentInChildren<RawImage>();
        
        raw.texture = rt;
    }
}
