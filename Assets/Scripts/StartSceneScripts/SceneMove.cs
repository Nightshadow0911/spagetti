using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMove : MonoBehaviour
{
   public void toCredit()
    {
        SceneFader.Instance.FadeToScene((int)SceneType.CreditScene);
    }

    public void toStart()
    {
        SceneFader.Instance.FadeToScene((int)SceneType.StartScene);
    }
}
