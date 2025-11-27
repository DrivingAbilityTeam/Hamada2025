using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LeadingBreak : MonoBehaviour
{
    [SerializeField] private float CarSpeed;

    [SerializeField] GameObject target;
    [SerializeField] GameObject car;
    [SerializeField] private float StartIn;
    [SerializeField] private float StartOut;
    Vector3 CarP;
    Vector3 TargetP;
    Vector3 now;
    private float disZ;
    private float DisZ;
    private float rad;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TargetP = target.transform.position;
        CarP = car.transform.position;
        disZ = Vector3.Distance(TargetP, CarP);//車とハザードの距離を測定
        rad = GetAngle(TargetP, CarP);//ハザードとの角度を算出
        DisZ = disZ * Mathf.Sin(rad);//Sin関数で距離に正負をつける
        Debug.Log(DisZ);

        if (StartOut <= DisZ || StartIn < disZ)
        {
            rb = this.GetComponent<Rigidbody>();  // rigidbodyを取得
            Vector3 now = rb.position;            // 座標を取得
            now += new Vector3(0.0f, 0.0f, -CarSpeed);  // 前に少しずつ移動するように加算
            rb.position = now; // 値を設定
            
        }
        
        

    }
    //二点の角度を求める関数
    float GetAngle(Vector3 TargetP, Vector3 CarP)
    {
        Vector3 dt = TargetP - CarP;
        float rad = Mathf.Atan2(dt.z, dt.x);
        return rad;
    }
}
