using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource BGM;

    // Start is called before the first frame update
    public void Start()
    {
        //���
        BGM.Play();

        //��Ʈ true > ���Ұ�
        BGM.mute = true;

        //���� true > �ݺ�
        BGM.loop = true;

        //�ڵ���� true >> �ڵ����
        BGM.playOnAwake = true;

        //����
        BGM.Stop();




    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
