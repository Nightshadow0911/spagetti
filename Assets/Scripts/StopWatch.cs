using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 

public class StopWatch : MonoBehaviour
    
{
    [SerializeField] float timestart;
    [SerializeField] Text timeText, startPauseText;

    bool timeActive = false;


    // Start is called before the first frame update
    void Start()
    {
        timeText.text = timestart.ToString("F2");

    }

    // Update is called once per frame
    void Update()
    {
        StartTime();
    }

    void StartTime()
    {
        if(timeActive)
        {
            timestart += Time.deltaTime;
            timeText.text = timestart.ToString("F2");

        }
    }
     
    public void StartPauseBtn()
    {
        timeActive = !timeActive;
        startPauseText.text = timeActive ? "PAUSE" : "START";

    }

    public void ResetBtn()
    {
        if(timestart > 0 )
        {
            timestart = 0f;
            timeText.text = timestart.ToString("F2");
        }
    }
}
