using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;

public class BallControl : MonoBehaviour
{
    public Rigidbody2D ballRigidbody;
    public GameObject paddle;
    public float moveSpeed = 5f;
    private Vector2 randomDirection;
    private bool isStopped;

    void Start()
    {
        ballRigidbody = GetComponent<Rigidbody2D>();
        randomDirection = new Vector2(1, 1).normalized;
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

        if (isStopped)
        {
            Transform paddleTransform = paddle.transform;
            float paddleXPosition = paddleTransform.position.x;
            transform.position = new Vector3(paddleXPosition, transform.position.y, 0);
        }

        if (Input.GetMouseButtonDown(0))
        {
            isStopped = false;
        }
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

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        HandleCollision(collision);
    }

    void HandleCollision(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            Destroy(collision.gameObject);
            Vector2 collisionVector = collision.contacts[0].point - (Vector2)collision.transform.position;
            Vector2 normalVector = collision.contacts[0].normal;
            float incidenceAngle = Vector2.Angle(randomDirection, -collisionVector);
            float reflectionAngle = 2 * incidenceAngle;
            Vector2 reflectionDirection = Quaternion.Euler(0, 0, reflectionAngle) * -collisionVector.normalized;
            randomDirection = reflectionDirection.normalized;
        }

        if (collision.gameObject.CompareTag("Paddle"))
        {
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
            Destroy(gameObject);
            GameManager.Instance.DecreaseLife();
        }
    }
}