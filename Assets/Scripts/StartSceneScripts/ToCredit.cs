using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToCredit : MonoBehaviour
{
   public void toCredit()
    {
        string nextSceneName = "CreditScene";
        FindObjectOfType<SceneFader>().FadeToScene(nextSceneName);
    }
}
