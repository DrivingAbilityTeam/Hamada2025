using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curve_Hit : MonoBehaviour
{
    public static int Curve_In = 0;
   

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider collider)//����ʉ߂����瑬�x���ω�����
    {

        
        if (collider.gameObject.tag == "Curve_In")//�ʉ߂�����o�C�N���o������
        {
            Curve_In++;
            

            //通過したボックスを消す
            collider.gameObject.SetActive(false);

        }
        


    }
    

}
