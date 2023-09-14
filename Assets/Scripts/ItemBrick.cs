using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBrick : MonoBehaviour
{
    public GameObject playerPaddle;
    public GameObject ball;

    public enum BrickItemEffect
    {
        PaddleSizeChange,
        BallSpeedChange,
        AddBall,
        MagenticBall,
        LifeUp
    }
    public float sizeChance = 0.2f;
    public float speedChance = 0.4f;
    public float addBallChance = 0.6f;
    public float MagenticBallChance = 0.8f;
    private BrickItemEffect ChooseItemEffect()
    {
        float randomValue = Random.Range(0f, 1f);

        if (randomValue < sizeChance)
        {
            return BrickItemEffect.PaddleSizeChange;
        }
        else if (randomValue < speedChance)
        {
            return BrickItemEffect.BallSpeedChange;
        }
        else if(randomValue < addBallChance)
        {
            return BrickItemEffect.AddBall;
        }
        else if(randomValue < MagenticBallChance)
        {
            return BrickItemEffect.MagenticBall;
        }
        else
        {
            return BrickItemEffect.LifeUp;
        }
    }
    private void ApplyItemEffect(BrickItemEffect effect)
    {
        switch (effect)
        {
            case BrickItemEffect.PaddleSizeChange:
                GameManager.Instance.Paddle.GetComponent<PaddleControl>().ChangeScale();
                break;
            case BrickItemEffect.BallSpeedChange:
                GameManager.Instance.Ball.GetComponent<BallControl>().BallSpeedChange();
                break;
            case BrickItemEffect.AddBall:
                Vector3 BallPosition = new Vector3 (0f, -3f, 0f);
                GameObject Ball = Instantiate(ball, BallPosition, Quaternion.identity);
                Ball.GetComponent<BallControl>().paddle = GameManager.Instance.Paddle;
                break;
            case BrickItemEffect.MagenticBall:
                GameManager.Instance.Ball.GetComponent<BallControl>().MagneticBall();
                break;
            case BrickItemEffect.LifeUp:
                GameManager.Instance.IncreaseLife();
                break;
        }
    }
    private void OnDestroy()
    {
        float random = Random.Range(0f, 1f);
        if (random < 0.2f)
        {
            if (GameManager.Instance.Ball != null && GameManager.Instance.Paddle != null)
            {
                BrickItemEffect selectedeffect = ChooseItemEffect(); // 랜덤 아이템 효과 선택
                ApplyItemEffect(selectedeffect); // 선택된 효과를 적용
            }
            
            
        }

    }
}
