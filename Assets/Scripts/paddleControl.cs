using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControl : MonoBehaviour //�е� ����
{
<<<<<<< HEAD

    public float paddleSpeed = 5f; // �е��� �̵� �ӵ�
    public GameObject paddle; // ������ �е鿡 ���� ����
    public Transform playerPaddle;
=======
>>>>>>> 2ba3b7999dee0b9c1a049c0fb481e2e34ce46711


    

    public GameObject paddlePrefab; // 패들 프리팹에 대한 참조
    public float paddleSpeed = 5f; // 패들의 이동 속도
   public GameObject paddle; // 생성된 패들에 대한 참조
  public Transform playerPaddle;


    void Start(){
    
    }

    void Update()
    {
        if (paddle != null) // 패들이 아직 생성되지 않았다면 업데이트하지 않습니다.
        {
            Vector3 currentScale = playerPaddle.localScale;
            float paddleHalfLength = currentScale.x / 2f;
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // X 축 위치를 마우스 포인터의 X 좌표로 고정
            transform.position = new Vector3(mousePosition.x, transform.position.y, transform.position.z);

            // 화면 경계 내에 고정
            float screenWidth = Camera.main.orthographicSize * Screen.width / Screen.height;
            float clampX = Mathf.Clamp(transform.position.x, -screenWidth + paddleHalfLength, screenWidth - paddleHalfLength);

            transform.position = new Vector3(clampX, transform.position.y, transform.position.z);
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