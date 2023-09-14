using System.Collections.Generic;
using UnityEngine;



public enum BGM
{
    MainMenu,
    InGame,
    Credit,
}

public enum SFX
{
    Break,
    Dead,
    LifeDown,
    OnHitBlock1,
    OnHitBlock2,
    OnHitBar,
    StageClear,
}

public class SoundManager : MonoBehaviour
{
    public enum Sounds
    {
        BGM,
        SFX,
        MaxCount,
    }

    private static SoundManager _instance;
    public static SoundManager Instance { get => _instance; }

    private AudioSource[] _audioSources = new AudioSource[(int)Sounds.MaxCount];

    private const string BGM_PATH = "Sounds/BGM";
    private const string SFX_PATH = "Sounds/SFX";
    public Dictionary<string, AudioClip> ClipDict { get; } = new Dictionary<string, AudioClip>();

    void Awake()
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

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        for (int i = 0; i < (int)Sounds.MaxCount; i++)
        {
            _audioSources[i] = gameObject.AddComponent<AudioSource>();
        }
        AudioClip[] bgms = Resources.LoadAll<AudioClip>(BGM_PATH);

        foreach (AudioClip clip in bgms)
        {
            ClipDict.Add(clip.name, clip);
        }

        AudioClip[] sfxs = Resources.LoadAll<AudioClip>(SFX_PATH);

        foreach (AudioClip clip in sfxs)
        {
            ClipDict.Add(clip.name, clip);
        }
    }

    public void PlayBGM(BGM bgm)
    {
        AudioSource audioSource = _audioSources[(int)Sounds.BGM];
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        audioSource.clip = ClipDict[bgm.ToString()];

        audioSource.Play();
    }

    public void PlaySFX(SFX sfx)
    {
        AudioSource audioSource = _audioSources[(int)Sounds.SFX];
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        audioSource.PlayOneShot(ClipDict[sfx.ToString()]);
    }

    public void SetBGMVolume(float value)
    {
        _audioSources[(int)Sounds.BGM].volume = value;
    }

    public float GetBGMVolume()
    {
        return _audioSources[(int)Sounds.BGM].volume;
    }

    public void SetSFXVolume(float value)
    {
        _audioSources[(int)Sounds.SFX].volume = value;
    }

    public float GetSFXVolume()
    {
        return _audioSources[(int)Sounds.SFX].volume;
    }
}
