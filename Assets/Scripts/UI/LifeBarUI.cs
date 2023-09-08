using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBarUI : MonoBehaviour
{
    [SerializeField] private RectTransform lifeBarRect;

    private Vector3 _currentPos = Vector3.zero;

    private GameObject[] lifeBars;

    void Start()
    {
        lifeBars = new GameObject[GameManager.Instance.MaxLifeBarCount];
        CreateLifeBars(GameManager.Instance.MaxLifeBarCount);
        UIManager.Instance.OnLifeChanged += SetActiveBarWhetherIncreasing;
    }

    private void CreateLifeBars(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject go = Instantiate(lifeBarRect, _currentPos, Quaternion.identity, transform).gameObject;
            _currentPos += new Vector3(lifeBarRect.rect.width, 0, 0);
            lifeBars[i] = go;
            if (i >= GameManager.Instance.Life)
            {
                go.SetActive(false);
            }
        }
    }

    private void SetActiveBarWhetherIncreasing(bool isIncreasing)
    {
        if (isIncreasing)
        {
            lifeBars[GameManager.Instance.Life].SetActive(true);
        }
        else
        {
            lifeBars[GameManager.Instance.Life - 1].SetActive(false);
        }
    }
}
