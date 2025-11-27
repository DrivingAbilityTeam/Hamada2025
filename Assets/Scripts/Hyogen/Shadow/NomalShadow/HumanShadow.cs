using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanShadow : MonoBehaviour
{
    [SerializeField] Transform ShadowT;
    [SerializeField] GameObject Shadow;
    [SerializeField] GameObject ShadowLight;
    [SerializeField] GameObject target;
    [SerializeField] GameObject car;
    [SerializeField] private float StartIn;//アラートを表示させる際の距離の判定値
    [SerializeField] private float StartOut;


    Vector3 CarP;
    Vector3 TargetP;
    Vector3 TargetBox;
    Vector3 size = new Vector3(0, 0, 0);

    private float disZ;
    private float DisZ;
    private float rad;
    private float zvalue = 1.193f;//影の初期位置
    private float dx = 0.0007f;
    private float dy = 0.0007f;
    private float dz = 0.0007f;
    private bool human;

    // Start is called before the first frame update
    void Start()
    {
        human = false;
        Shadow.gameObject.SetActive(false);
        ShadowLight.SetActive(false);
        ShadowT.transform.localPosition = new Vector3(0.457f, 1.11f, 1.193f);//影を初期位置に戻す
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

            if (StartOut <= DisZ && DisZ < StartIn)//前方からハザードの接近を検知
            {
                //影とライトをオンにする
                Shadow.gameObject.SetActive(true);
                ShadowLight.SetActive(true);

                //影を後方に動かす
                zvalue -= 0.0022f;
                Vector3 pos = new Vector3(0.457f, 1.11f, zvalue);
                ShadowT.transform.localPosition = pos;


                //影を拡大する
                size.x += dx;
                size.y += dy;
                size.z += dz;
                ShadowT.transform.localScale = size;

                if (zvalue <= 0.914f)//
                {
                    zvalue = 1.193f;
                    ShadowT.transform.localPosition = new Vector3(0.457f, 1.11f, 1.193f);//影を初期位置に戻す

                    if (size.y > 0.016f)//一定のサイズを超えたら元に戻す
                    {
                        size = new Vector3(0, 0, 0);
                        ShadowT.transform.localScale = size;

                    }
                }

            }

            if (DisZ < StartOut)//ハザードが前にいるときはオフにする
            {
                Shadow.gameObject.SetActive(false);
                ShadowLight.SetActive(false);

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
}
