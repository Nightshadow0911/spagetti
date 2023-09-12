using UnityEngine;

public class BrickControl : MonoBehaviour
{
    // Start 함수 대신 이 함수를 사용하여 초기화합니다.
    public void InitializeBrick(Vector3 position)
    {
        transform.position = position;
    }
}