using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Bike_Distance : MonoBehaviour
{


    [SerializeField] GameObject target1;

    [SerializeField] GameObject car;

    Vector3 CarP;
    Vector3 TargetP1;


    private float disZ1;//��������p
    public static float DisZ1;
    private float rad1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Bike_SetActive.Bike_status)
        {
            TargetP1 = target1.transform.position;

            CarP = car.transform.position;

            disZ1 = Vector3.Distance(TargetP1, CarP);//�Ԃƃn�U�[�h�̋����𑪒�
            rad1 = GetAngle(TargetP1, CarP);//�n�U�[�h�Ƃ̊p�x���Z�o
            DisZ1 = disZ1 * Mathf.Sin(rad1);//Sin�֐��ŋ����ɐ���������
            //Debug.Log(DisZ1);
        }


    }

    float GetAngle(Vector3 TargetP, Vector3 CarP)
    {
        Vector3 dt = TargetP - CarP;
        float rad = Mathf.Atan2(dt.z, dt.x);
        return rad;
    }

}