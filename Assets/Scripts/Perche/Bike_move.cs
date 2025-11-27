using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class Bike_move : MonoBehaviour
{

    private float CarSpeed;
    [SerializeField] Transform Car;
    // Start is called before the first frame update

    public static bool bike_roop;

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
        /*
        Rigidbody rb = this.GetComponent<Rigidbody>();  // rigidbody���擾
        Vector3 now = rb.position;            // ���W���擾
        now += new Vector3(0.0f, 0.0f, -CarSpeed/3.6f*Time.deltaTime);  // �O�ɏ������ړ�����悤�ɉ��Z
        rb.position = now; */ //�l��ݒ�

        transform.position += transform.forward  *(CarSpeed / 3.6f * Time.deltaTime);
    }

}

