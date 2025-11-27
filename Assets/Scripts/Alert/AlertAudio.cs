using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AlertAudio : MonoBehaviour
{
    public AudioClip sound1;
    AudioSource audioSource;//Audioソース型の変数

    [SerializeField] GameObject target;
    [SerializeField] GameObject car;
    [SerializeField] private float StartIn;//アラートを表示させる際の距離の判定値
    [SerializeField] private float StartOut;

    
    private float disZ;
    private float DisZ;
    private float rad;
    Vector3 CarP;
    Vector3 TargetP;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        TargetP = target.transform.position;
        CarP = car.transform.position;

        disZ = Vector3.Distance(TargetP, CarP);//車とハザードの距離を測定
        rad = GetAngle(TargetP, CarP);//ハザードとの角度を算出
        DisZ = disZ * Mathf.Sin(rad);//Sin関数で距離に正負をつける

        if (StartOut <=  DisZ && DisZ < StartIn)
        {
            
            audioSource.PlayOneShot(sound1);//ハザード接近したらアラートが鳴る

        }
        
        if (DisZ < StartOut)//通り過ぎた場合
        {
            audioSource.Stop();
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
