using UnityEngine;

public class BrickControl : MonoBehaviour
{
    // Start �Լ� ��� �� �Լ��� ����Ͽ� �ʱ�ȭ�մϴ�.
    public void InitializeBrick(Vector3 position)
    {
        transform.position = position;
        transform.localScale = new Vector3(1.0f, 0.3f, 1.0f); // ������ ������ ũ��
    }
}