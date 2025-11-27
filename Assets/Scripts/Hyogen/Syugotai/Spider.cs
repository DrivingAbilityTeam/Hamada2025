using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.ParticleSystem;



public class Spider : MonoBehaviour
{
    public enum HyogenType
    {
        Spider_Normal,
        Spider_Ougi,
    }
    [SerializeField] private  HyogenType m_HasuType = HyogenType.Spider_Normal;
    public GameObject[] signs;
    private GameObject Particle;

    private List<ParticleSystem> _particleSystems;
    [SerializeField] private float _spped;

    [SerializeField] GameObject target;
    [SerializeField] GameObject car;
    [SerializeField] private float StartIn;
    [SerializeField] private float StartOut;


    Vector3 CarP;
    Vector3 TargetP;

    private float disZ;
    private float DisZ;
    private float rad;


    private void Start()
    {
        switch (m_HasuType)
        {
            case HyogenType.Spider_Normal:
                Particle = signs[0];
                break;

            case HyogenType.Spider_Ougi:
                Particle = signs[1];
                break;

        }
        
        Particle.SetActive(false);
        _particleSystems = Particle.GetComponentsInChildren<ParticleSystem>().ToList();
    }



    void Update()
    {
        TargetP = target.transform.position;
        CarP = car.transform.position;

        disZ = Vector3.Distance(TargetP, CarP);//�Ԃƃn�U�[�h�̋����𑪒�
        rad = GetAngle(TargetP, CarP);//�n�U�[�h�Ƃ̊p�x���Z�o
        DisZ = disZ * Mathf.Sin(rad);//Sin�֐��ŋ����ɐ���������


        if (StartOut <= DisZ && DisZ < StartIn && Hit.hit)
        {
            Particle.SetActive(true);
            
        }

        if (DisZ < StartOut || !Hit.hit)
        {
            Particle.SetActive(false);
            Hit.hit = false;
        }

    }

    //��_�̊p�x�����߂�֐�
    float GetAngle(Vector3 TargetP, Vector3 CarP)
    {
        Vector3 dt = TargetP - CarP;
        float rad = Mathf.Atan2(dt.z, dt.x);
        return rad;
    }

    //�w�肵���p�[�e�B�N���̑��x��ύX
    private void ChangeSpeed(ParticleSystem particle, float speed)
    {
        var main = particle.main;
        main.simulationSpeed = speed;
    }

}
