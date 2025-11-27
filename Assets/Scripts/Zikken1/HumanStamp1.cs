using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HumanStamp1 : MonoBehaviour
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
        

        if (Input.GetKeyDown(KeyCode.A))
        {
            CarframeMaterial.sharedMaterial.EnableKeyword("_EMISSION");//�h�A�t���[���𔭌�������
            //OnAnim = true;
            //animator.SetBool("Human", OnAnim);//�A�j���[�V�������I���ɂ���

            Hyogen.SetActive(true);

        }

        if (Input.GetKeyDown(KeyCode.B))
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