using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToCredit : MonoBehaviour
{
   public void toCredit()
    {
        SceneFader.Instance.FadeToScene((int)SceneType.CreditScene);
    }
}
