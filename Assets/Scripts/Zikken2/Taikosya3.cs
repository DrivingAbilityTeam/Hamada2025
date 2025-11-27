using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Taikosya3 : MonoBehaviour
{
   
    [SerializeField] private float StartSpeed;
    [SerializeField] Transform Car;

    [SerializeField] GameObject target;
    [SerializeField] GameObject car;
    //右折ライト
    [SerializeField] GameObject Right_move;

    Vector3 CarP;
    Vector3 TargetP;

    public static bool stop;//ハザード出現用
    public static bool Rstart;//右折開始用
    private float disZ;//��������p
    private float DisZ;
    private float rad;
    private float CarSpeed;

    // Start is called before the first frame update
    void Start()
    {
        CarSpeed = StartSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        TargetP = target.transform.position;
        CarP = car.transform.position;

        disZ = Vector3.Distance(TargetP, CarP);//�Ԃƃn�U�[�h�̋����𑪒�
        rad = GetAngle(TargetP, CarP);//�n�U�[�h�Ƃ̊p�x���Z�o
        DisZ = disZ * Mathf.Sin(rad);//Sin�֐��ŋ����ɐ���������

        if(DisZ < 20){
            CarSpeed = (StartSpeed/10)*-DisZ - StartSpeed;
            Right_move.SetActive(true);
        }

        Vector3 now2 = this.transform.position;            
        now2 += new Vector3(0.0f, 0.0f, -CarSpeed/3.6f*Time.deltaTime);  
        this.transform.position = now2;

        
    
    }

    float GetAngle(Vector3 TargetP, Vector3 CarP)
    {
        Vector3 dt = TargetP - CarP;
        float rad = Mathf.Atan2(dt.z, dt.x);
        return rad;
    }

}