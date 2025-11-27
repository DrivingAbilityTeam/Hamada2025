using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.ParticleSystem;

public class Smo_Color_Changer : MonoBehaviour
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

    [SerializeField] private float C_R1;
    [SerializeField] private float C_R2;
    [SerializeField] private float C_R3;
    [SerializeField] private float C_R4;
    [SerializeField] private float C_R5;
    [SerializeField] private float C_R6;


    Vector3 CarP;
    Vector3 TargetP;

    private float disZ;//��������p
    private float DisZ;
    private float rad;

    [SerializeField] ParticleSystem RedParticle;
    Color color;
    
    private void Start()
    {
        Particle.SetActive(false);
        color = RedParticle.startColor;
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

            /*if(color.r < 1.0f)
            {
                Color c = color;
                c.r += 0.002f;
                color = c;
        
            }*/

            Color c = color;
            c.r = C_R1;
            color = c;

            ColorChange(RedParticle, color);
            if (StartOut <= DisZ && DisZ < StartIn1)
            {
                c = color;
                c.r = C_R2;
                color = c;
                ColorChange(RedParticle, color);

            }
            if (StartOut <= DisZ && DisZ < StartIn2)
            {
                c = color;
                c.r = C_R3;
                color = c;
                ColorChange(RedParticle, color);

            }
            if (StartOut <= DisZ && DisZ < StartIn3)
            {
                c = color;
                c.r = C_R4;
                color = c;
                ColorChange(RedParticle, color);

            }
            if (StartOut <= DisZ && DisZ < StartIn4)
            {
                c = color;
                c.r = C_R5;
                color = c;
                ColorChange(RedParticle, color);

            }
            if (StartOut <= DisZ && DisZ < StartIn5)
            {
                c = color;
                c.r = C_R6;
                color = c;
                ColorChange(RedParticle, color);

            }
        }

        if (DisZ < StartOut || !Hit.hit)
        {
            Particle.SetActive(false);
            Color c = color;
            c.r = 0;
            color = c;
        }

    }

    //��_�̊p�x�����߂�֐�
    float GetAngle(Vector3 TargetP, Vector3 CarP)
    {
        Vector3 dt = TargetP - CarP;
        float rad = Mathf.Atan2(dt.z, dt.x);
        return rad;
    }

    

    private void ColorChange(ParticleSystem particle, Color color)
    {
        
        var main = particle.main;
        main.startColor = new ParticleSystem.MinMaxGradient(color);
    }

}
