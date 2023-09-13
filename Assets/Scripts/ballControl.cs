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
    private bool isMagnetic=false;
    private Transform paddleTransform;
    public float magneticRadius = 1.5f;
    private bool isPoweredUp = false;
    private float powerUpDuration = 10.0f;

    private Vector2 _initPos;

    void Start()
    {
        _initPos = transform.position;

        ballRigidbody = GetComponent<Rigidbody2D>();
        paddleTransform = paddle.transform;
        randomDirection = new Vector2(1, 1).normalized;
        if (ballRigidbody != null)
        {
            ballRigidbody.velocity = Vector2.zero;
        }
        
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

        if (isMagnetic)
        {
            // 공과 패들 사이의 거리 계산
            float distance = Vector2.Distance(transform.position, paddleTransform.position);

            if (distance <= magneticRadius)
            {
                 // 자석 효과 종료
                ballRigidbody.velocity = Vector2.zero;
                isStopped = true;
                isMagnetic = false;
            }
        }


    }

    private void Reset()
    {
        isStopped = true;
        transform.parent = paddle.transform;
        transform.position = _initPos;

    }

    private void Shoot()
    {
        isStopped = false;
        transform.parent = null;
    }

    public void BallSpeedChange()
    {
        float randomValue = Random.Range(0f, 1f);
        if (moveSpeed == 10f)
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
        isMagnetic = true;
    }
    public void BallPowerUp()
    {   
        if (!isPoweredUp)
        {
            isPoweredUp = true;
            StartCoroutine(EndPowerUp());
            
        }
    }
    private IEnumerator EndPowerUp()
    {
        // 일정 시간 후 강화 종료
        yield return new WaitForSeconds(powerUpDuration);

        // 강화 종료
        isPoweredUp = false;
        //강화된 부분을 다시 되돌리는 부분이 필요
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        HandleCollision(collision);
    }

    void HandleCollision(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            GameManager.Instance.RemoveBrickFromList(collision.collider.GetComponent<BrickControl>());
            Vector2 collisionVector = collision.contacts[0].point - (Vector2)collision.transform.position;
            Vector2 normalVector = collision.contacts[0].normal;
            float incidenceAngle = Vector2.Angle(randomDirection, -collisionVector);
            float reflectionAngle = 2 * incidenceAngle;
            Vector2 reflectionDirection = Quaternion.Euler(0, 0, reflectionAngle) * -collisionVector.normalized;
            randomDirection = reflectionDirection.normalized;

            SoundManager.Instance.PlaySFX(SFX.Break);
            GameManager.Instance.AddScore(score);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Paddle"))
        {
            SoundManager.Instance.PlaySFX(SFX.OnHitBar);
            randomDirection.y *= -1;
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
        }
    }
}