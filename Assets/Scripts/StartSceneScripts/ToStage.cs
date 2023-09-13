using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToStage : MonoBehaviour
{
    public void toStage()
    {
        SceneFader.Instance.FadeToScene((int)SceneType.Stage1);
    }
}
