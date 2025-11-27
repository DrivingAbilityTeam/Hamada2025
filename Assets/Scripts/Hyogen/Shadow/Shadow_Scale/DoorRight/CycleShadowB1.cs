using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleShadowB1 : MonoBehaviour
{
    [SerializeField] GameObject Shadow;
    [SerializeField] Transform ShadowT;
    [SerializeField] GameObject ShadowLight;
    [SerializeField] GameObject target;
    [SerializeField] GameObject car;
    [SerializeField] private float StartIn;//�A���[�g��\��������ۂ̋����̔���l
    [SerializeField] private float StartOut;


    Vector3 CarP;
    Vector3 TargetP;
    Vector3 size = new Vector3(0, 0, 0);

    private float disZ;//��������p
    private float DisZ;
    private float rad;
    private float zvalue = 0.560f;//�e�̏����ʒu
    private float dx = 0.15f;//�X�P�[���ω��p
    private float dy = 0.15f;
    private float dz = 0.15f;
    private bool human;

    // Start is called before the first frame update
    void Start()
    {
        Shadow.gameObject.SetActive(false);
        ShadowLight.SetActive(false);
        ShadowT.transform.localPosition = new Vector3(0.586f, 1.0f, 0.560f);//�e�������ʒu�ɖ߂�
    }

    // Update is called once per frame
    void Update()
    {
        TargetP = target.transform.position;
        CarP = car.transform.position;

        disZ = Vector3.Distance(TargetP, CarP);//�Ԃƃn�U�[�h�̋����𑪒�
        rad = GetAngle(TargetP, CarP);//�n�U�[�h�Ƃ̊p�x���Z�o
        DisZ = disZ * Mathf.Sin(rad);//Sin�֐��ŋ����ɐ���������

        

        if (StartOut >= DisZ && DisZ > StartIn && human)
        {

            
            Shadow.gameObject.SetActive(true);
            ShadowLight.SetActive(true);

            //�e��O���ɓ�����
            zvalue += 0.01f;
            Vector3 pos = new Vector3(0.586f, 1.0f, zvalue);
            ShadowT.transform.localPosition = pos;

            //�e���g�傷��
            size.x += dx*Time.deltaTime;;
            size.y += dy*Time.deltaTime;;
            size.z += dz*Time.deltaTime;;
            ShadowT.transform.localScale = size;

            if (zvalue >= 1.2f)
            {
                zvalue = 0.560f;
                ShadowT.transform.localPosition = new Vector3(0.586f, 1.0f, 0.560f);//�e�������ʒu�ɖ߂�

                if (size.x > 0.1f)
                {

                    size = new Vector3(0, 0, 0);
                    ShadowT.transform.localScale = size;

                }
            }

        }
        if (DisZ > StartOut || !human)
        {
            Shadow.gameObject.SetActive(false);
            ShadowLight.SetActive(false);

        }
    }

    //��_�̊p�x�����߂�֐�
    float GetAngle(Vector3 TargetP, Vector3 CarP)
    {
        Vector3 dt = TargetP - CarP;
        float rad = Mathf.Atan2(dt.z, dt.x);
        return rad;
    }

    void OnTriggerStay(Collider collider)//�����_�ʉߔ���
    {
        if (collider.gameObject.tag == "CurveTarget")
        {
            //�e�ƃ��C�g���I���ɂ���
            human = true;

        }
    }

    void OnTriggerExit(Collider collider)//�����_�ʉߔ���
    {
        if (collider.gameObject.tag == "CurveTarget")
        {
            //�e�ƃ��C�g���I���ɂ���
            human = false;

        }
    }
}