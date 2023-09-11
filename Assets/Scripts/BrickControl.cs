using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickControl : MonoBehaviour
{
    public GameObject brickPrefab; // 벽돌 프리팹에 대한 참조
    public Vector2 startPosition = new Vector2(-8f, 4f); // 시작 위치
    public float brickWidth = 1.0f; // 벽돌의 너비
    public float brickHeight = 0.5f; // 벽돌의 높이
    public int rows = 5; // 행 수
    public int columns = 10; // 열 수

    // 벽돌 배열 데이터 (1은 벽돌이 있는 위치, 0은 빈 공간을 나타냅니다)
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
                // 벽돌 배열 데이터를 기반으로 벽돌을 생성하거나 빈 공간을 스킵합니다.
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
