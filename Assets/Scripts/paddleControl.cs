using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControl : MonoBehaviour
{
    public GameObject paddlePrefab; // �е� �����տ� ���� ����
    public float paddleSpeed = 5f; // �е��� �̵� �ӵ�
   public GameObject paddle; // ������ �е鿡 ���� ����

    void Start()
    {
        // �е��� �����ϰ� �ʱ� ��ġ�� ��ġ�մϴ�.
        paddle = Instantiate(paddlePrefab, transform.position, Quaternion.identity);
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
}