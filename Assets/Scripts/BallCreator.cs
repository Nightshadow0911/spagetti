using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCreator : MonoBehaviour
{
    [SerializeField] private BallControl ball;

    private void Start()
    {
        GameManager.Instance.OnResetCallback += InstantiateBall;
    }

    public void InstantiateBall()
    {
        Instantiate(ball);
    }
}
