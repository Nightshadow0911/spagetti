using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballControl : MonoBehaviour           //��������
{
    public Rigidbody2D ballRigidbody;
    public GameObject paddle;
    public float moveSpeed = 5f;
    private Vector2 randomDirection;
    private bool isStopped;

    void Start()
    {
        ballRigidbody = GetComponent<Rigidbody2D>();
        randomDirection = new Vector2(1, 1).normalized; //�� ó�� ���۹���
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


        if (transform.position.x < -9 || transform.position.x > 9) //ȭ�� �¿�ܰ��� �ε������� ���� ƨ���
        {
            randomDirection.x *= -1;
        }

        if (transform.position.y > 5) //ȭ�� ���� �ܰ��� �ε�������
        {
            randomDirection.y *= -1;
        }

        if(transform.position.y < -5) //ȭ�� �Ʒ������� ����������
        {
            randomDirection.y *= -1; //�ӽ�
            //���� �Ʒ��� ���������� �� ���� �� ü�� ���� �׸� �߰�
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
        if (collision.gameObject.CompareTag("Brick")) //������ �浹������ ������ �ı��ϰ� ���� ������ �ݴ��
        {
            Destroy(collision.gameObject);
            randomDirection.x *= -1;
            randomDirection.y *= -1;
        }

        if (collision.gameObject.CompareTag("Paddle")) //�е�� �ε������� ���� ƨ�ܳ�������
        {
            randomDirection.y *= -1;
        }
    }
}