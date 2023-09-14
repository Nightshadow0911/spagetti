using Unity.VisualScripting;
using UnityEngine;

public enum BrickType
{ 
    white,
    Red,
    Green,
    Yellow,
    Blue,
    Black,
}

public class BrickControl : MonoBehaviour
{
    [field : SerializeField]
    public int Life { get; private set; }
    public GameObject ball;
    private SpriteRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }


    public void InitializeBrick(Vector3 position, int life)
    {
        transform.position = position;
        SetLife(life);
    }

    public void DecreaseLife(BallControl ball)
    {
        Life -= ball.GetComponent<BallControl>().ballPower;
        if (Life <= 0)
        {
            SoundManager.Instance.PlaySFX(SFX.Break);
            GameManager.Instance.RemoveBrickFromList(this);
            Destroy(gameObject);
            return;
        }
        else
        {
            int ranNum = Random.Range(0, 2);

            if (ranNum == 0)
            {
                SoundManager.Instance.PlaySFX(SFX.OnHitBlock1);
            }
            else
            {
                SoundManager.Instance.PlaySFX(SFX.OnHitBlock2);
            }
        }

        SetColor();
    }

    private void SetColor()
    {
        BrickType type = (BrickType)(Life - 1);
        switch (type)
        {
            case BrickType.white:
                _renderer.color = Color.white;
                break;
            case BrickType.Red:
                _renderer.color = Color.red;
                break;
            case BrickType.Yellow:
                _renderer.color = Color.yellow;
                break;
            case BrickType.Green:
                _renderer.color = Color.green;
                break;
            case BrickType.Blue:
                _renderer.color = Color.blue;
                break;
            case BrickType.Black:
                _renderer.color = Color.black;
                break;
        }
    }

    private void SetLife(int life)
    {
        Life = life;
        SetColor();
    }


}