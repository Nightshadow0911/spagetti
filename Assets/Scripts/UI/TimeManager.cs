using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;


public class TimeManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Stopwatch watch = new Stopwatch();
        watch.Start();

        watch.Stop();
        UnityEngine.Debug.Log(watch.ElapsedMilliseconds +"ms");

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
