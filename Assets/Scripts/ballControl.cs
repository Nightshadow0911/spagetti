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
            Destroy(gameObject); //공 제거
            GameManager.Instance.DecreaseLife();//체력 감소 스크립트 재생
        }

        if (isStopped)
        {
            Transform paddleTransform = paddle.transform;
            float paddleXPosition = paddleTransform.position.x;
            transform.position = new Vector3(paddleXPosition, transform.position.y, 0);
        }

        if (Input.GetMouseButtonDown(0)) //마우스따라 움직이도록
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
        if (collision.gameObject.CompareTag("Brick")) //벽돌과 충돌했을때 벽돌을 파괴하고 공이 튕겨나가도록
        {
            Destroy(collision.gameObject);
            // 벽돌의 중심과 충돌 지점을 연결한 벡터
            Vector2 collisionVector = collision.contacts[0].point - (Vector2)collision.transform.position;

            // 법선 벡터 (벽돌 표면의 방향)
            Vector2 normalVector = collision.contacts[0].normal;

            // 입사각 계산
            float incidenceAngle = Vector2.Angle(randomDirection, -collisionVector);

            // 반사 각도 계산 (정반사)
            float reflectionAngle = 2 * incidenceAngle;

            // 반사 방향 벡터 계산
            Vector2 reflectionDirection = Quaternion.Euler(0, 0, reflectionAngle) * -collisionVector.normalized;

            // 새로운 방향으로 공의 이동 방향 설정
            randomDirection = reflectionDirection.normalized;
        }

        if (collision.gameObject.CompareTag("Paddle")) //패들과 부딪혔을때 공이 튕겨나가도록
        {
            randomDirection.y *= -1;
        }
    }
}