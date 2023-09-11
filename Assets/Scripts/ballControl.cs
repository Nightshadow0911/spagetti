using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballControl : MonoBehaviour           //랜덤방향
{
    public Rigidbody2D ballRigidbody;
    public GameObject paddle;
    public float moveSpeed = 5f;
    private Vector2 randomDirection;
    private bool isStopped;

    void Start()
    {
        ballRigidbody = GetComponent<Rigidbody2D>();
        randomDirection = new Vector2(1, 1).normalized; //공 처음 시작방향
        //randomDirection = Random.insideUnitCircle.normalized;
        if (ballRigidbody != null)
        {
            ballRigidbody.velocity = Vector2.zero;
        }
        isStopped = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(randomDirection * moveSpeed * Time.deltaTime);


        if (transform.position.x < -9 || transform.position.x > 9) //화면 좌우외곽에 부딪혔을때 공이 튕기게
        {
            randomDirection.x *= -1;
        }

        if (transform.position.y > 5) //화면 위쪽 외곽에 부딪혔을때
        {
            randomDirection.y *= -1;
        }

        if(transform.position.y < -5) //화면 아래쪽으로 떨어졌을때
        {
            randomDirection.y *= -1; //임시
            //공이 아래로 떨어졌을때 공 삭제 및 체력 감소 항목 추가
        }

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
    void OnCollisionEnter2D(Collision2D collision)
    {
        HandleCollision(collision);
    }

    void HandleCollision(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick")) //벽돌과 충돌했을때 벽돌을 파괴하고 공의 방향을 반대로
        {
            Destroy(collision.gameObject);
            randomDirection.x *= -1;
            randomDirection.y *= -1;
        }

        if (collision.gameObject.CompareTag("Paddle")) //패들과 부딪혔을때 공이 튕겨나가도록
        {
            randomDirection.y *= -1;
        }
    }
}