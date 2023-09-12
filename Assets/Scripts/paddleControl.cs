using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControl : MonoBehaviour //패들 관련
{

    public float paddleSpeed = 5f; // 패들의 이동 속도
    public GameObject paddle; // 생성된 패들에 대한 참조
    public Transform playerPaddle;

    void Start()
    {

    }

    void Update()
    {
        if (paddle != null) // 패들이 아직 생성되지 않았다면 업데이트하지 않습니다.
        {
            Vector3 currentScale = paddle.transform.localScale; // 패들 객체의 스케일 가져오기
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            float x = mousePos.x;

            float paddleHalfLength = currentScale.x / 2f; // 패들의 길이가 변해도 화면 밖으로 나가지 않음
            if (x + paddleHalfLength > 8.9f)
            {
                x = 8.9f - paddleHalfLength;
            }
            if (x - paddleHalfLength < -8.9f)
            {
                x = -8.9f + paddleHalfLength;
            }

            // 패들 객체의 위치를 업데이트합니다.
            paddle.transform.position = new Vector3(x, paddle.transform.position.y, 0);
        }
    }
    public void ChangeScale()
    {
        float randomValue = Random.Range(0f, 1f);
        Vector3 currentScale = transform.localScale;
        if (playerPaddle.localScale.x == 1f)
        {
            currentScale.x += 0.5f;
            transform.localScale = currentScale;
        }
        else
        {
            if (randomValue < 0.5f)
            {
                currentScale.x += 0.5f;
                transform.localScale = currentScale;
            }
            else
            {
                currentScale.x -= 0.5f;
                transform.localScale = currentScale;
            }
        }
    }
}