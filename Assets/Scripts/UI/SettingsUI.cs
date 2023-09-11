using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    [SerializeField] private TMP_Text bgmText;
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private TMP_Text sfxText;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Button closeButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private GameObject settingsObj;

    private void Start()
    {
        bgmSlider.onValueChanged.AddListener(SoundManager.Instance.SetBGMVolume);
        bgmSlider.onValueChanged.AddListener(ChangeBGMText);
        sfxSlider.onValueChanged.AddListener(SoundManager.Instance.SetSFXVolume);
        sfxSlider.onValueChanged.AddListener(ChangeSFXText);

        closeButton.onClick.AddListener(CloseSettings);
        settingsButton.onClick.AddListener(OpenSettings);

        settingsObj.SetActive(false);
    }

    private void ChangeBGMText(float ratio)
    {
        bgmText.text = $"BGM : {(int)(ratio * 100)}";
    }

    private void ChangeSFXText(float ratio)
    {
        sfxText.text = $"SFX : {(int)(ratio * 100)}";
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
