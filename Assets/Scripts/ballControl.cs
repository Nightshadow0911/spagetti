using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;

public class ballControl : MonoBehaviour           //��������
{
    public Rigidbody2D ballRigidbody;
    public GameObject paddle;
    public float moveSpeed = 5f;
    private Vector2 randomDirection;
    private bool isStopped;

    private Vector2 _initPos;

    void Start()
    {
        _initPos = transform.position;

        ballRigidbody = GetComponent<Rigidbody2D>();
        randomDirection = new Vector2(1, 1).normalized; //�� ó�� ���۹���
        //randomDirection = Random.insideUnitCircle.normalized;
        if (ballRigidbody != null)
        {
            ballRigidbody.velocity = Vector2.zero;
        }

        Reset();
    }

    // Update is called once per frame
    void Update()
    {

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
            //Destroy(gameObject); //�� ����
            GameManager.Instance.DecreaseLife();//ü�� ���� �׸� �߰�
            Reset();

        }

        if (isStopped)
        {
            Transform paddleTransform = paddle.transform;
            float paddleXPosition = paddleTransform.position.x;
            transform.position = new Vector3(paddleXPosition, transform.position.y, 0);
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();

                //if (ballRigidbody != null)
                //{
                //    ballRigidbody.velocity = randomDirection * moveSpeed;
                //}
            }
        }
        else
        {
            transform.Translate(randomDirection * moveSpeed * Time.deltaTime);
        }

        /*if (Input.GetMouseButtonDown(0)) //���콺���� �����̵���
        {
            isStopped = false;

            if (ballRigidbody != null)
            {
                ballRigidbody.velocity = randomDirection * moveSpeed;
            }
        }*/
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
        if (collision.gameObject.CompareTag("Brick")) //������ �浹������ ������ �ı��ϰ� ���� ƨ�ܳ�������
        {
            Destroy(collision.gameObject);
            Vector2 collisionVector = collision.contacts[0].point - (Vector2)collision.transform.position;
            Vector2 normalVector = collision.contacts[0].normal;
            float incidenceAngle = Vector2.Angle(randomDirection, -collisionVector);
            float reflectionAngle = 2 * incidenceAngle;
            Vector2 reflectionDirection = Quaternion.Euler(0, 0, reflectionAngle) * -collisionVector.normalized;
            randomDirection = reflectionDirection.normalized;
        }

        if (collision.gameObject.CompareTag("Paddle")) //�е�� �ε������� ���� ƨ�ܳ�������
        {
            randomDirection.y *= -1;
        }
    }
}