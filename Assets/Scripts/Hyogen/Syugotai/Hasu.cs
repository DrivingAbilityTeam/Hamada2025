using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.ParticleSystem;



public class Hasu : MonoBehaviour
{
    public enum HyogenType
    {
        HasuCircle,
        HasuSquare,
    }
    [SerializeField] private HyogenType m_HasuType = HyogenType.HasuCircle;
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
            case HyogenType.HasuCircle:
                Particle = signs[0];
                break;

            case HyogenType.HasuSquare:
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


        if (StartOut <= DisZ && DisZ < StartIn && Hit.hit)//ハザードが前方にいる、かつ車が交差点内にいる場合
        {
            Particle.SetActive(true);

        }

        if (DisZ < StartOut || !Hit.hit)//ハザードが通過、または車が交差点を離れた場合
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
