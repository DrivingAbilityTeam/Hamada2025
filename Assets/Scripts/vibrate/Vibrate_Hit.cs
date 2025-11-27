using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vibrate_Hit : MonoBehaviour
{
    public static int Vibrate_Status = 0;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    Debug.Log(Vibrate_Status);
    }
    void OnTriggerEnter(Collider collider)//����ʉ߂����瑬�x���ω�����
    {

        if (collider.gameObject.tag == "Vibration_Start")//�ʉ߂�����o�C�N���o������
        {
            Vibrate_Status = 1;
            //通過したボックスを消す
            collider.gameObject.SetActive(false);
        }
        if (collider.gameObject.tag == "Vibration_Change")//�ʉ߂�����o�C�N���o������
        {
            Vibrate_Status = 2;
            //通過したボックスを消す
            collider.gameObject.SetActive(false);
            
        }
        if (collider.gameObject.tag == "Vibration_Stop")//�ʉ߂�����o�C�N���o������
        {
            Vibrate_Status = 0;
            //通過したボックスを消す
            collider.gameObject.SetActive(false);
        }



    }
    

}
