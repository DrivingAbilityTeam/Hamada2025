using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FootStampAnim : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] GameObject car;
    [SerializeField] private float StartIn;//アラートを表示させる際の距離の判定値
    [SerializeField] private float StartOut;
    [SerializeField] GameObject Carframe;
    Renderer CarframeMaterial;

    Vector3 CarP;
    Vector3 TargetP;

    private float disZ;//距離測定用
    private float DisZ;
    private float rad;
    private bool human;


    public GameObject Shadow;

    // Start is called before the first frame update
    void Start()
    {
        CarframeMaterial = Carframe.GetComponent<MeshRenderer>();
        human = false;
        Shadow.SetActive(false);
        CarframeMaterial.sharedMaterial.DisableKeyword("_EMISSION");

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
           
           CarframeMaterial.sharedMaterial.EnableKeyword("_EMISSION");//ドアフレームを発光させる


            if (StartOut >= DisZ && DisZ > StartIn)
            {
                Debug.Log(DisZ);
                //OnAnim = true;
                //animator.SetBool("Human", OnAnim);//アニメーションをオンにする

                Shadow.SetActive(true);
                
            }

            if (DisZ > StartOut)
            {
                CarframeMaterial.sharedMaterial.DisableKeyword("_EMISSION");
                Shadow.SetActive(false);
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