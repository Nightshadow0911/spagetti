using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControl : MonoBehaviour
{

    public float paddleSpeed = 5f; // 패들의 이동 속도
    public GameObject paddle; // 생성된 패들에 대한 참조
    public Transform playerPaddle;



    void Start(){
    
    }

    void Update()
    {
        if (paddle != null)
        {
            Vector3 currentScale = playerPaddle.localScale;
            float paddleHalfLength = currentScale.x / 2f;
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            transform.position = new Vector3(mousePosition.x, transform.position.y, transform.position.z);

            // ?붾㈃ 寃쎄퀎 ?댁뿉 怨좎젙
            float screenWidth = Camera.main.orthographicSize * Screen.width / Screen.height;
            float clampX = Mathf.Clamp(transform.position.x, -screenWidth + paddleHalfLength, screenWidth - paddleHalfLength);

            transform.position = new Vector3(clampX, transform.position.y, transform.position.z);
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