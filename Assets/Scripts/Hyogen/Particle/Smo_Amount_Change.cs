using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.ParticleSystem;

public class Smo_Amount_Change : MonoBehaviour
{


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
    [SerializeField] private float StartIn6;

    [SerializeField] private float Amo1;
    [SerializeField] private float Amo2;
    [SerializeField] private float Amo3;
    [SerializeField] private float Amo4;
    [SerializeField] private float Amo5;
    [SerializeField] private float Amo6;
    [SerializeField] private float Amo7;

    [SerializeField] private float scale_x1;
    [SerializeField] private float scale_x2;
    [SerializeField] private float scale_x3;
    [SerializeField] private float scale_x4;



    Vector3 CarP;
    Vector3 TargetP;

    private float disZ;//��������p
    private float DisZ;
    private float rad;

    [SerializeField] ParticleSystem RedParticle;
    private Vector3 scale;

    private void Start()
    {
        Particle.SetActive(false);
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
            AmountChange(RedParticle, Amo1);

            if (StartOut <= DisZ && DisZ < StartIn1)
            {
                AmountChange(RedParticle, Amo2);
            }
            if (StartOut <= DisZ && DisZ < StartIn2)
            {
                AmountChange(RedParticle, Amo3);
            }
            if (StartOut <= DisZ && DisZ < StartIn3)
            {
                AmountChange(RedParticle, Amo4);
                scale = new Vector3(scale_x1, 0, 1);
                ScaleChange(RedParticle, scale);
            }
            if (StartOut <= DisZ && DisZ < StartIn4)
            {
                AmountChange(RedParticle, Amo5);
                scale = new Vector3(scale_x2, 0, 1);
                ScaleChange(RedParticle, scale);
            }
            if (StartOut <= DisZ && DisZ < StartIn5)
            {
                AmountChange(RedParticle, Amo6);
                scale = new Vector3(scale_x3, 0, 1);
                ScaleChange(RedParticle, scale);
            }
            if (StartOut <= DisZ && DisZ < StartIn6)
            {
                AmountChange(RedParticle, Amo7);
                scale = new Vector3(scale_x4, 0, 1);
                ScaleChange(RedParticle, scale);
            }
        }

        if (DisZ < StartOut || !Hit.hit)
        {
            Particle.SetActive(false);
            AmountChange(RedParticle, Amo1);
            scale = new Vector3(0.5f, 0, 1);
            ScaleChange(RedParticle, scale);
        }

    }

    //��_�̊p�x�����߂�֐�
    float GetAngle(Vector3 TargetP, Vector3 CarP)
    {
        Vector3 dt = TargetP - CarP;
        float rad = Mathf.Atan2(dt.z, dt.x);
        return rad;
    }

    

    private void AmountChange(ParticleSystem particle, float amount)
    {

        var em = particle.emission;
        em.rateOverTime = amount;
    }
    private void ScaleChange(ParticleSystem particle, Vector3 scale)
    {

        var shape = particle.shape;
        shape.scale = scale;
    }

}
