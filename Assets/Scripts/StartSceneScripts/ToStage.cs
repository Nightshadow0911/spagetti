using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToStage : MonoBehaviour
{
    [SerializeField] private int stageNum = 1;

    public void toStage()
    {
        SceneFader.Instance.FadeToScene(stageNum);
    }

    
}
