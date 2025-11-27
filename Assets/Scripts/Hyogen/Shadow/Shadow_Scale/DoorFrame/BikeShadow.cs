using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BikeShadow : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] GameObject car;
    [SerializeField] private float StartIn;//�A���[�g��\��������ۂ̋����̔���l
    [SerializeField] private float StartOut;
    [SerializeField] GameObject Carframe;
    Renderer CarframeMaterial;

    Vector3 CarP;
    Vector3 TargetP;

    private float disZ;//��������p
    private float DisZ;
    private float rad;


    public GameObject Shadow;

    // Start is called before the first frame update
    void Start()
    {
        CarframeMaterial = Carframe.GetComponent<MeshRenderer>();
        Shadow.SetActive(false);
        CarframeMaterial.sharedMaterial.DisableKeyword("_EMISSION");

    }

    // Update is called once per frame
    void Update()
    {
        TargetP = target.transform.position;
        CarP = car.transform.position;

        disZ = Vector3.Distance(TargetP, CarP);//�Ԃƃn�U�[�h�̋����𑪒�
        rad = GetAngle(TargetP, CarP);//�n�U�[�h�Ƃ̊p�x���Z�o
        DisZ = disZ * Mathf.Sin(rad);//Sin�֐��ŋ����ɐ���������

            if (StartOut <= DisZ && DisZ < StartIn && Hit.hit)
            {
                CarframeMaterial.sharedMaterial.EnableKeyword("_EMISSION");//�h�A�t���[���𔭌�������
                Shadow.SetActive(true);

            }

            if (DisZ < StartOut || !Hit.hit)
            {
                CarframeMaterial.sharedMaterial.DisableKeyword("_EMISSION");
                Shadow.SetActive(false);
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
