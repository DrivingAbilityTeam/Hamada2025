using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LeadingCar2 : MonoBehaviour
{
   
    [SerializeField] private float CarSpeed;
    [SerializeField] Transform Car;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*
        Rigidbody rb = this.GetComponent<Rigidbody>();  // rigidbodyを取得
        Vector3 now = rb.position;            // 座標を取得
        now += new Vector3(0.0f, 0.0f, -CarSpeed/3.6f*Time.deltaTime);  // 前に少しずつ移動するように加算
        rb.position = now; */ //値を設定

        transform.position += transform.forward * (CarSpeed / 3.6f * Time.deltaTime);
    }
    
}
