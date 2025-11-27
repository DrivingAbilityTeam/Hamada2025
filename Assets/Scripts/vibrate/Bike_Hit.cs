using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bike_Hit : MonoBehaviour
{
    public static int bike_Active = 0;
    

    public static bool perche_Active;
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

        if (collider.gameObject.tag == "Bike_Active")//�ʉ߂�����o�C�N���o������
        {
            bike_Active++;
            //通過したボックスを消す
            collider.gameObject.SetActive(false);
        }
        


    }
    

}
