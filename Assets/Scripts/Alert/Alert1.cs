using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class Alert1 : MonoBehaviour
{

    [SerializeField] GameObject Alert;
    [SerializeField] GameObject target;
    [SerializeField] GameObject car;
    [SerializeField] private float StartIn;//�A���[�g��\��������ۂ̋����̔���l
    [SerializeField] private float StartOut;


    Vector3 CarP;
    Vector3 TargetP;

    private float disZ;
    private float DisZ;
    private float rad;

    // Start is called before the first frame update
    void Start()
    {
        Alert.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        TargetP = target.transform.position;
        CarP = car.transform.position;

        disZ = Vector3.Distance(TargetP, CarP);//�Ԃƃn�U�[�h�̋����𑪒�
        rad = GetAngle(TargetP, CarP);//�n�U�[�h�Ƃ̊p�x���Z�o
        DisZ = disZ * Mathf.Sin(rad);//Sin�֐��ŋ����ɐ���������
        


        if (StartOut <= DisZ && DisZ < StartIn)
        {
           
            Alert.SetActive(true);//�A���[�g�\��
        }
        if (DisZ < StartOut)
        {
            Alert.SetActive(false);

        }
    }

    //��_�̊p�x�����߂�֐�
    float GetAngle(Vector3 TargetP, Vector3 CarP)
    {
        Vector3 dt = TargetP - CarP;
        float rad = Mathf.Atan2(dt.z, dt.x);
        return rad;
    }
}
