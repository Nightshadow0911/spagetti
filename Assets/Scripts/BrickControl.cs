using UnityEngine;

public class BrickControl : MonoBehaviour
{
    // Start �Լ� ��� �� �Լ��� ����Ͽ� �ʱ�ȭ�մϴ�.
    public void InitializeBrick(Vector3 position)
    {
        transform.position = position;
    }
}