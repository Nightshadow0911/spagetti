using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControl : MonoBehaviour //�е� ����
{

    public float paddleSpeed = 5f; // �е��� �̵� �ӵ�
    public GameObject paddle; // ������ �е鿡 ���� ����
    public Transform playerPaddle;

    void Start()
    {

    }

    void Update()
    {
        if (paddle != null) // �е��� ���� �������� �ʾҴٸ� ������Ʈ���� �ʽ��ϴ�.
        {
            Vector3 currentScale = paddle.transform.localScale; // �е� ��ü�� ������ ��������
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            float x = mousePos.x;

            float paddleHalfLength = currentScale.x / 2f; // �е��� ���̰� ���ص� ȭ�� ������ ������ ����
            if (x + paddleHalfLength > 8.9f)
            {
                x = 8.9f - paddleHalfLength;
            }
            if (x - paddleHalfLength < -8.9f)
            {
                x = -8.9f + paddleHalfLength;
            }

            // �е� ��ü�� ��ġ�� ������Ʈ�մϴ�.
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