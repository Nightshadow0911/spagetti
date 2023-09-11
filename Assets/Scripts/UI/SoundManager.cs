using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource blockDeadSound;
    public AudioSource playerDeadSound;
    public AudioSource itemGainSound;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);

        }
        DontDestroyOnLoad(gameObject);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
