using UnityEngine;

public class BrickControl : MonoBehaviour
{
    // Start 함수 대신 이 함수를 사용하여 초기화합니다.
    public void InitializeBrick(Vector3 position)
    {
        transform.position = position;
        transform.localScale = new Vector3(1.0f, 0.3f, 1.0f); // 벽돌의 고정된 크기
    }
}