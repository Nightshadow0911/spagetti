using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class BallControll : MonoBehaviour               //마우스방향
//{
//    public Rigidbody2D ballRigidbody;
//    public GameObject paddle;
//    public float moveSpeed = 5f;
//    private bool isStopped;

//    void Start()
//    {
//        if (ballRigidbody != null)
//        {
//            ballRigidbody.velocity = Vector2.zero;
//        }
//        isStopped = true;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (!isStarted)
//        {
//            Transform paddleTransform = paddle.transform;
//            float paddleXPosition = paddleTransform.position.x;
//            transform.position = new Vector3(paddleXPosition, transform.position.y, 0);
//        }
//        if (Input.GetMouseButtonDown(0))
//        {
//            isStopped = false;
//            // 마우스 클릭한 지점의 위치를 가져옵니다.
//            Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//            targetPosition.z = 0f; // 2D 게임에서는 Z 축을 0으로 설정합니다.

//            // 공을 클릭한 위치로 이동시킵니다.
//            if (ballRigidbody != null)
//            {
//                Vector2 direction = (targetPosition - transform.position).normalized;
//                ballRigidbody.velocity = direction * moveSpeed;
//            }
//        }
//    }
//}
public class BallControl : MonoBehaviour           //랜덤방향
{
    public Rigidbody2D ballRigidbody;
    public GameObject paddle;
    public float moveSpeed = 5f;
    private Vector2 randomDirection;
    private bool isStopped;

    void Start()
    {
        ballRigidbody = GetComponent<Rigidbody2D>();
        Transform paddleTransform = paddle.transform;
        float paddleXPosition = paddleTransform.position.x;
        transform.position = new Vector3(paddleXPosition, -3.5f, 0);   
        randomDirection = Random.insideUnitCircle.normalized;
        if (ballRigidbody != null)
        {
            ballRigidbody.velocity = Vector2.zero;
        }
        isStopped = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isStopped)
        {
            Transform paddleTransform = paddle.transform;
            float paddleXPosition = paddleTransform.position.x;
            transform.position = new Vector3(paddleXPosition, transform.position.y, 0);
        }
        if (Input.GetMouseButtonDown(0))
        {
            isStopped = false;

            if (ballRigidbody != null)
            {
                ballRigidbody.velocity = randomDirection * moveSpeed;
            }
        }
    }
    public void BallSpeedChange()
    {
        float randomValue = Random.Range(0f, 1f);
        if (moveSpeed == 5f)
        {
            moveSpeed += 2f;
        }
        else
        {
            if (randomValue < 0.5f)
            {
                moveSpeed += 2f;
            }
            else
            {
                moveSpeed -= 2f;
            }
        }
    }
    public void MagneticBall()
    {

    }
}
