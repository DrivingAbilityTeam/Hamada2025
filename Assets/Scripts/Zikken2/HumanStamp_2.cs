using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HumanStamp_2 : MonoBehaviour
{  public enum HyogenType
    {
        Up,
        Middle,
        Down,
        SizeDown
    }
    [SerializeField] private HyogenType RedType = HyogenType.Middle;
    public GameObject[] signs;
    private GameObject Hyogen;

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

    // Start is called before the first frame update
    void Start()
    {
        switch (RedType)
        {
            case HyogenType.Up:
                Hyogen = signs[0];
                break;

            case HyogenType.Middle:
                Hyogen = signs[1];
                break;

            case HyogenType.Down:
                Hyogen = signs[2];
                break;

            case HyogenType.SizeDown:
                Hyogen = signs[3];
                break;

        }

        CarframeMaterial = Carframe.GetComponent<MeshRenderer>();
        Hyogen.SetActive(false);
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
        Debug.Log(DisZ);

        if (StartOut >= DisZ && DisZ > StartIn && Hit.hit)
        {
            CarframeMaterial.sharedMaterial.EnableKeyword("_EMISSION");//�h�A�t���[���𔭌�������
            //OnAnim = true;
            //animator.SetBool("Human", OnAnim);//�A�j���[�V�������I���ɂ���

            Hyogen.SetActive(true);

        }

        if (DisZ > StartOut || !Hit.hit || StartIn > DisZ)
        {
            CarframeMaterial.sharedMaterial.DisableKeyword("_EMISSION");
            Hyogen.SetActive(false);
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