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
public class Particle_Transform : MonoBehaviour
{

    [SerializeField]private float Po1;
    [SerializeField] private float Po2;
    [SerializeField] private float Po3;
    [SerializeField] private float Po4;
    [SerializeField] private float Po5;
    [SerializeField] private float Po6;

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
        Vector3 position = Particle.transform.position;

        if (StartOut <= DisZ && DisZ < StartIn && Hit.hit)
        {
            Particle.SetActive(true);
            position.y = Po1;
            Particle.transform.position = position;
            
            if (StartOut <= DisZ && DisZ < StartIn1)
            {
                position.y = Po2;
                Particle.transform.position = position;
            }
            if (StartOut <= DisZ && DisZ < StartIn2)
            {
                position.y = Po3;
                Particle.transform.position = position;
            }
            if (StartOut <= DisZ && DisZ < StartIn3)
            {
                position.y = Po4;
                Particle.transform.position = position;
            }
            if (StartOut <= DisZ && DisZ < StartIn4)
            {
                position.y = Po5;
                Particle.transform.position = position;
            }
            if (StartOut <= DisZ && DisZ < StartIn5)
            {
                position.y = Po6;
                Particle.transform.position = position;
            }
        
        }

        if (DisZ < StartOut || !Hit.hit)
        {
            Particle.SetActive(false);
        position.y = Po1;
            Particle.transform.position = position;
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