using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class Bike_Speedup : MonoBehaviour
{

    private float CarSpeed;
    [SerializeField] Transform Car;
    // Start is called before the first frame update
    private bool Speedup_mode = false;

    
    [SerializeField] private float ChangeSpeed;

    public enum SpeedType
    {
        speed_30, speed_40, speed_50, speed_70
    }
    [Header("�o�C�N�̑��x��I�����Ă�������")]
    public SpeedType speed_type;


    void Start()
    {
        if (speed_type == SpeedType.speed_30)
        {
            CarSpeed = 30f;
        }
        if (speed_type == SpeedType.speed_40)
        {
            CarSpeed = 40f;
        }
        if (speed_type == SpeedType.speed_50)
        {
            CarSpeed = 50f;
        }
        if (speed_type == SpeedType.speed_70)
        {
            CarSpeed = 70f;
        }
    }

    

    // Update is called once per frame
    void Update()
    {
       

        transform.position += transform.forward  *(CarSpeed / 3.6f * Time.deltaTime);
        

        if (Speedup_mode)
        {
            CarSpeed += 10f * Time.deltaTime;         

            if (CarSpeed > ChangeSpeed)
            {
                CarSpeed = ChangeSpeed;
            }
        }

    }
    

    void OnTriggerEnter(Collider collider)//����ʉ߂����瑬�x���ω�����
{


        if (collider.gameObject.tag == "Bike_Speedup")//�ʉ߂�����o�C�N���o������
        {
            Speedup_mode = true;
           
            //通過したボックスを消す
            collider.gameObject.SetActive(false);

         }



 }
}

