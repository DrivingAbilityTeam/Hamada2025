using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_Bike : MonoBehaviour
{
    public static bool bike_Active;
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
            bike_Active = true;
            perche_Active = true;
        }


    }
    void OnTriggerExit(Collider collider)//����ʉ߂����瑬�x���ω�����
    {

        if (collider.gameObject.tag == "Bike_Active")//�ʉ߂�����o�C�N���o������
        {

            perche_Active = false;
        }


    }

}
