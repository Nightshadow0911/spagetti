using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    [SerializeField] private TMP_Text volumeText;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private TMP_Text resolutionText;
    [SerializeField] private Slider resolutionSlider;
    [SerializeField] private Button closeButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private GameObject settingsObj;

    private void Start()
    {
        volumeSlider.onValueChanged.AddListener(ChangeVolumeText);
        resolutionSlider.onValueChanged.AddListener(ChangeResolutionText);
        closeButton.onClick.AddListener(CloseSettings);
        settingsButton.onClick.AddListener(OpenSettings);

        settingsObj.SetActive(false);
    }

    private void ChangeResolutionText(float ratio)
    {
         volumeText.text = $"Volume : {(int)(ratio * 100)}";
    }

    private void ChangeVolumeText(float ratio)
    {
        resolutionText.text = $"Resolution : {(int)(ratio * 100)}";
    }

    private void CloseSettings()
    {
        settingsButton.gameObject.SetActive(true);
        settingsObj.SetActive(false);
    }

    private void OpenSettings()
    {
        settingsButton.gameObject.SetActive(false);
        settingsObj.SetActive(true);
    }
}
