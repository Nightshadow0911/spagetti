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
        BallPowerUp,
        MagenticBall
    }
    public float sizeChance = 0.2f;
    public float speedChance = 0.4f;
    public float addBallChance = 0.6f;
    public float ballPowerUpChance = 0.8f;
    //public float MagenticBallChance = 1.0f;
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
        else if (randomValue < ballPowerUpChance)
        {
            return BrickItemEffect.BallPowerUp;
        }
        else
        {
            return BrickItemEffect.MagenticBall;
        }
    }
    private void ApplyItemEffect(BrickItemEffect effect)
    {
        switch (effect)
        {
            case BrickItemEffect.PaddleSizeChange:
                playerPaddle.GetComponent<PaddleControl>().ChangeScale();
                break;
            case BrickItemEffect.BallSpeedChange:
                ball.GetComponent<BallControl>().BallSpeedChange();
                break;
            case BrickItemEffect.AddBall:
                GameObject newObject = Instantiate(ball, transform.position, Quaternion.identity);
                break;
            case BrickItemEffect.BallPowerUp:
                ball.GetComponent<BallControl>().BallPowerUp();
                break;
            case BrickItemEffect.MagenticBall:
                ball.GetComponent<BallControl>().MagneticBall();
                break;

        }
    }
    private void OnDestroy()
    {
        BrickItemEffect selectedEffect = ChooseItemEffect(); // 랜덤 아이템 효과 선택
        ApplyItemEffect(selectedEffect); // 선택된 효과를 적용
    }
}
