using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform playerPaddle;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentScale = playerPaddle.localScale;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float x = mousePos.x;

        float paddleHalfLength = currentScale.x / 2f;    //�е��� ���̰� ���ص� ȭ�� ������ ������ ����
        if (x + paddleHalfLength > 8.9f)
        {
            x = 8.9f - paddleHalfLength;
        }
        if (x - paddleHalfLength < -8.9f)
        {
            x = -8.9f + paddleHalfLength;
        }
        transform.position = new Vector3(x, transform.position.y, 0);
    }
}
