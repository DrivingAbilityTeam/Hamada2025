using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hasu2 : MonoBehaviour
{
    //オブジェクトを徐々に透明にするスクリプト
    [SerializeField] MeshRenderer mesh1;
    [SerializeField] MeshRenderer mesh2;

    [SerializeField] GameObject target;
    [SerializeField] GameObject car;
    [SerializeField] private float StartIn;//アラートを表示させる際の距離の判定値
    [SerializeField] private float StartOut;
    [SerializeField] GameObject Shadow;

    Vector3 CarP;
    Vector3 TargetP;

    private float disZ;//距離測定用
    private float DisZ;
    private float rad;
    private bool human;


    // Start is called before the first frame update
    void Start()
    {  
        human = true;

    }

    void Update()
    {
        TargetP = target.transform.position;
        CarP = car.transform.position;

        disZ = Vector3.Distance(TargetP, CarP);//車とハザードの距離を測定
        rad = GetAngle(TargetP, CarP);//ハザードとの角度を算出
        DisZ = disZ * Mathf.Sin(rad);//Sin関数で距離に正負をつける


        if (human)
        {
            
            if (StartOut <= DisZ && DisZ < StartIn)
            {
                StartCoroutine("TransparentSta");

            }

            if (DisZ < StartOut)
            {
                StartCoroutine("TransparentFin");
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


    IEnumerator TransparentSta()
    {
        if(mesh1.material.color.a > 142 )
        {
            yield return null;
        }

        mesh1.material.color = mesh1.material.color + new Color32(0, 0, 0, 1);
        mesh2.material.color = mesh2.material.color + new Color32(0, 0, 0, 1);
        yield return new WaitForSeconds(0.01f);

    }

    IEnumerator TransparentFin()
    {
        if (mesh1.material.color.a <0 )
        {
            Shadow.SetActive(false);
            yield return null;
        }

        mesh1.material.color = mesh1.material.color - new Color32(0, 0, 0, 2);
        mesh2.material.color = mesh2.material.color - new Color32(0, 0, 0, 2);
        yield return new WaitForSeconds(0.01f);
        
    }
}
