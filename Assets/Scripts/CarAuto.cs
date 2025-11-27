using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAuto : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      Rigidbody rb = this.GetComponent<Rigidbody> ();  // rigidbodyを取得
      Vector3 now = rb.position;            // 座標を取得
      now += new Vector3 (0.0f,0.0f,0.03f);  // 前に少しずつ移動するように加算
      rb.position = now; // 値を設定
      
      Vector3 pos = transform.position;
      pos.x += 0.362f;
      pos.y += 1.178f;
      pos.z += 0.198f;
      GameObject camera = GameObject.Find("Camera");
      camera.transform.position = pos;
    }
}
