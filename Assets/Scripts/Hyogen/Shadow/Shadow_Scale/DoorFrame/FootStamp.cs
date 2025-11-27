using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FootStamp : MonoBehaviour
{
    [SerializeField] GameObject Shadow;

    [SerializeField] GameObject target;
    [SerializeField] GameObject car;
    [SerializeField] private float StartIn;//アラートを表示させる際の距離の判定値
    [SerializeField] private float StartOut;
    [SerializeField] private float StartIn_2;//アラートを表示させる際の距離の判定値
    [SerializeField] private float StartOut_2;
    [SerializeField] private float StartIn_3;//アラートを表示させる際の距離の判定値
    [SerializeField] private float StartOut_3;

    Vector3 CarP;
    Vector3 TargetP;

    private float disZ;//距離測定用
    private float DisZ;
    private float rad;
    private bool human;
    private int count = 0;


    // Start is called before the first frame update
    void Start()
    {
       
        human = false;
        Shadow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        TargetP = target.transform.position;
        CarP = car.transform.position;

        disZ = Vector3.Distance(TargetP, CarP);//車とハザードの距離を測定
        rad = GetAngle(TargetP, CarP);//ハザードとの角度を算出
        DisZ = disZ * Mathf.Sin(rad);//Sin関数で距離に正負をつける
        

        if (human)
        {
            Debug.Log(DisZ);
            if (StartOut >= DisZ && DisZ > StartIn && count==0)//足跡1回目
            {
                
                Debug.Log(DisZ);
                Shadow.SetActive(true);
                Invoke("FadeOut",1.1f);
                count = 1;
            }
            if (StartOut_2 >= DisZ && DisZ > StartIn_2 && count == 1)//足跡2回目
            {
                Shadow.SetActive(true);
                Invoke("FadeOut", 1.1f);
                count = 2;
                Debug.Log(DisZ);
            }
            if (StartOut_3 >= DisZ && DisZ > StartIn_3 && count == 2)//足跡3回目
            {
                Shadow.SetActive(true);
                Invoke("FadeOut", 1.8f);
                count = 3;
                Debug.Log(DisZ);
            }

            if (DisZ > StartOut)
            {

                Shadow.SetActive(false);
                Debug.Log(DisZ);
            }
        }
    }

    //二点の角度を求める関数
    float GetAngle(Vector3 TargetP, Vector3 CarP)
    {
        Vector3 dt = TargetP - CarP;
        float rad = Mathf.Atan2(dt.z, dt.x);
        return rad;
    }

    void OnTriggerEnter(Collider collider)//交差点通過判定
    {
        if (collider.gameObject.tag == "CurveTarget")
        {
            //影とライトをオンにする
            human = true;

        }

        if (collider.gameObject.tag == "ResetTarget")
        {
            //影とライトをオフにする
            human = false;

        }
    }

    void FadeIn()
    {
        Shadow.SetActive(true);
        
    }
    void FadeOut()
    {
        Shadow.SetActive(false);
        
    }
}