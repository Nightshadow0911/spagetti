using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickControl : MonoBehaviour
{
    public GameObject brickPrefab; // ���� �����տ� ���� ����
    public Vector2 startPosition = new Vector2(-8f, 4f); // ���� ��ġ
    public float brickWidth = 1.0f; // ������ �ʺ�
    public float brickHeight = 0.5f; // ������ ����
    public int rows = 5; // �� ��
    public int columns = 10; // �� ��

    // ���� �迭 ������ (1�� ������ �ִ� ��ġ, 0�� �� ������ ��Ÿ���ϴ�)
    private int[,] brickArray = new int[,]
    {
        {1, 0, 1, 1, 1, 0, 1, 1, 1, 1},
        {1, 1, 1, 1, 0, 1, 1, 1, 0, 1},
        {1, 1, 1, 1, 1, 1, 0, 1, 1, 1},
        {0, 1, 1, 1, 1, 1, 1, 1, 1, 1},
        {1, 1, 1, 1, 1, 1, 1, 1, 1, 0}
    };

    void Start()
    {
        CreateBrickArray();
    }

    void CreateBrickArray()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                // ���� �迭 �����͸� ������� ������ �����ϰų� �� ������ ��ŵ�մϴ�.
                if (brickArray[row, col] == 1)
                {
                    Vector3 brickPosition = new Vector3(startPosition.x + col * brickWidth, startPosition.y - row * brickHeight, 0);
                    Instantiate(brickPrefab, brickPosition, Quaternion.identity);
                }
            }
        }
    }

    void Update()
    {
        
    }
}
