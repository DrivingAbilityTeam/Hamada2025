using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    //�Փ˂��Ă�Ԃ̂ݕ\�����I���ɂ��邽�߂̃X�N���v�g
    public static bool hit;

    [SerializeField] GameObject target;
    [SerializeField] GameObject car;
    Vector3 CarP;
    Vector3 TargetP;

    private float disZ;//��������p
    private float DisZ;
    private float rad;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        TargetP = target.transform.position;
        CarP = car.transform.position;

        disZ = Vector3.Distance(TargetP, CarP);//�Ԃƃn�U�[�h�̋����𑪒�
        rad = GetAngle(TargetP, CarP);//�n�U�[�h�Ƃ̊p�x���Z�o
        DisZ = disZ * Mathf.Sin(rad);//Sin�֐��ŋ����ɐ���������
        //Debug.Log(DisZ);
    }

    // Update is called once per frame
    void OnTriggerStay(Collider collider)//�R���C�_�ɓ������Ă���Ԃ̂ݕ\���̃I���I�t���ł���悤�ɂ���
    {
        if (collider.gameObject.tag == "CurveTarget")
        {

            hit = true;

        }

    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "CurveTarget")
        {
          
            hit = false;

        }

    }

     float GetAngle(Vector3 TargetP, Vector3 CarP)
    {
        Vector3 dt = TargetP - CarP;
        float rad = Mathf.Atan2(dt.z, dt.x);
        return rad;
    }

}
