using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.ParticleSystem;

/// <summary>
/// �p�[�e�B�N���̃X�s�[�h��ς���N���X
/// </summary>
public class ParticleSpeed : MonoBehaviour
{

    [SerializeField]private float _speed1;
    [SerializeField] private float _speed2;
    [SerializeField] private float _speed3;
    [SerializeField] private float _speed4;
    [SerializeField] private float _speed5;
    [SerializeField] private float _speed6;

    [SerializeField] private GameObject Particle;
    [SerializeField] GameObject target;
    [SerializeField] GameObject car;
    [SerializeField] private float StartIn;//�A���[�g��\��������ۂ̋����̔���l
    [SerializeField] private float StartOut;
    [SerializeField] private float StartIn1;
    [SerializeField] private float StartIn2;
    [SerializeField] private float StartIn3;
    [SerializeField] private float StartIn4;
    [SerializeField] private float StartIn5;

    Vector3 CarP;
    Vector3 TargetP;

    private float disZ;//��������p
    private float DisZ;
    private float rad;

    [SerializeField] ParticleSystem particle;

    //=================================================================================
    //������
    //=================================================================================

    private void Start()
    {
        Particle.SetActive(false);
    }

    //=================================================================================
    //�C�x���g
    //=================================================================================

    

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
            ChangeSpeed(particle, _speed1);
            
            if (StartOut <= DisZ && DisZ < StartIn1)
            {
                 ChangeSpeed(particle, _speed2);
                  
            }
            if (StartOut <= DisZ && DisZ < StartIn2)
            {
                 ChangeSpeed(particle, _speed3);

            }
            if (StartOut <= DisZ && DisZ < StartIn3)
            {
                 ChangeSpeed(particle, _speed4);

            }
            if (StartOut <= DisZ && DisZ < StartIn4)
            {
                 ChangeSpeed(particle, _speed5);

            }
            if (StartOut <= DisZ && DisZ < StartIn5)
            {
                 ChangeSpeed(particle, _speed6);

            }
        
        }

        if (DisZ < StartOut || !Hit.hit)
        {
            Particle.SetActive(false);
            ChangeSpeed(particle, _speed1);
        }

    }

    //��_�̊p�x�����߂�֐�
    float GetAngle(Vector3 TargetP, Vector3 CarP)
    {
        Vector3 dt = TargetP - CarP;
        float rad = Mathf.Atan2(dt.z, dt.x);
        return rad;
    }

    //=================================================================================
    //�ύX
    //=================================================================================

    //�w�肵���p�[�e�B�N���̑��x��ύX
    private void ChangeSpeed(ParticleSystem particle, float speed)
    {
        var velocity = particle.velocityOverLifetime;
        velocity.speedModifier = speed;
    }

}