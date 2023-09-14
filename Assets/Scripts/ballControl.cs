using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;

public class BallControl : MonoBehaviour
{
    [SerializeField] private int score = 100;

    public Rigidbody2D ballRigidbody;
    public GameObject paddle;
    public float moveSpeed = 5f;
    public float accelerationRate = 0.2f;
    private Vector2 randomDirection;
    private bool isStopped;
    private Transform paddleTransform;
    public float magneticRadius = 1.5f;
    private bool isPowereUp = false;
    private float powerUpDuration = 10.0f;
    public int ballPower = 1;
    public bool IsMagnetic { get; set; }

    private Vector2 _initPos;

    void Start()
    {
        _initPos = transform.position;

        ballRigidbody = GetComponent<Rigidbody2D>();
        paddleTransform = paddle.transform;
        
        if (ballRigidbody != null)
        {
            ballRigidbody.velocity = Vector2.zero;
        }
        moveSpeed = 5f;
        Reset();

    }

    // Update is called once per frame
    void Update()
    {
        if (isStopped)
        {
            float paddleXPosition = paddleTransform.position.x;
            transform.position = new Vector3(paddleXPosition, transform.position.y, 0);

            if (Input.GetMouseButtonDown(0))
            {
                isStopped = false;
                Shoot();
            }
        }
        else
        {
            moveSpeed += accelerationRate * Time.deltaTime;
            transform.Translate(randomDirection * moveSpeed * Time.deltaTime);
        }

        
    }

    private void Reset()
    {
        randomDirection = new Vector2(1, 1).normalized;
        isStopped = true;
        transform.position = _initPos;
        moveSpeed = 5f;
    }

    private void Shoot()
    {
        isStopped = false;
        transform.parent = null;
    }

    public void BallSpeedChange()
    {
        float randomValue = Random.Range(0f, 1f);
        if (moveSpeed <= 5f)
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
                moveSpeed -= 3f;
            }
        }
    }
    public void MagneticBall()
    {
        IsMagnetic = true;
        if (ballRigidbody != null)
        {
            ballRigidbody.velocity = Vector2.zero;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        HandleCollision(collision);
    }

    void HandleCollision(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            BrickControl brickControl = collision.collider.GetComponent<BrickControl>();
            Vector2 collisionVector = collision.contacts[0].point - (Vector2)collision.transform.position;
            Vector2 normalVector = collision.contacts[0].normal;

            // 입사 각도 계산
            float incidenceAngle = Vector2.Angle(randomDirection, -collisionVector);

            // 최소 반사 각도 설정 (예: 30도)
            float minReflectionAngle = 30f;

            if (incidenceAngle < minReflectionAngle)
            {
                // 입사 각도가 최소 반사 각도보다 작으면 최소 반사 각도로 설정
                incidenceAngle = minReflectionAngle;
            }

            // 반사 각도 계산
            float reflectionAngle = 2 * incidenceAngle;
            Vector2 reflectionDirection = Quaternion.Euler(0, 0, reflectionAngle) * -collisionVector.normalized;

            // 공의 방향을 반사 방향으로 설정하여 공이 벽돌에서 튕겨 나가도록 합니다.
            randomDirection = reflectionDirection.normalized;

            brickControl.DecreaseLife(this);
            SoundManager.Instance.PlaySFX(SFX.Break);
            GameManager.Instance.AddScore(score);
        }

        if (collision.gameObject.CompareTag("Paddle"))
        {
            if (IsMagnetic)
            {
                Reset();
                IsMagnetic = false;
            }

            SoundManager.Instance.PlaySFX(SFX.OnHitBar);

            Vector2 collisionvector = collision.contacts[0].point;
            Vector2 paddleCenter = paddleTransform.position;

            float paddleWidth = paddleTransform.localScale.x;

            float halfPaddleWidth = paddleWidth / 2f;

            float distanceFromCenter = collisionvector.x - paddleCenter.x;
            float relativePositionRatio = distanceFromCenter / halfPaddleWidth;

            float minReflectionAngle = -45f;
            float maxReflectionAngle = 45f;

            float reflectionAngle = Mathf.Lerp(minReflectionAngle, maxReflectionAngle, (relativePositionRatio + 1f) / 2f);

            Vector2 newDirection = Quaternion.Euler(0, 0, reflectionAngle) * Vector2.up;
            randomDirection = newDirection.normalized;
        }

        if (collision.gameObject.CompareTag("horizontal"))
        {
            randomDirection.y *= -1;
        }
        if (collision.gameObject.CompareTag("vertical"))
        {
            randomDirection.x *= -1;
        }
        if (collision.gameObject.CompareTag("deadline")) //아래 내려가면 공 파괴, 체력감소
        {
            SoundManager.Instance.PlaySFX(SFX.LifeDown);
            Reset();
            GameManager.Instance.DecreaseLife();
            moveSpeed = 5.0f;
        }
    }
}