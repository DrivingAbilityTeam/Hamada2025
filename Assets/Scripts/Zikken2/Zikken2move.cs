using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Zikken2move : MonoBehaviour
{
    [SerializeField] PathCreator pathCreator;
    private float moveSpeed;
    [SerializeField] private float SlowSpeed;
    [SerializeField] GameObject car;

    Vector3 CarP;
    Vector3 TargetP1;
    Vector3 TargetP2;
    private float disZ1;
    private float disZ2;
    private float SpeedZ;
    private bool human = false;
    private Rigidbody rb;

    public static bool Honda_Start;

    Vector3 endPos;
 
    float moveDistance;
 
    void Start()
    {
        moveSpeed = 0f;
        endPos = pathCreator.path.GetPoint(pathCreator.path.NumPoints - 1);//アセット提供のメソッドを使用：最終地点の座標を取得（経路上の点の数 ー１）
        rb = car.GetComponent<Rigidbody>();  // rigidbodyを取得
    }
 
    void Update()
    {     

        if (!human)//通常時
        {
            //開始地点からの経路上の距離を指定し点の座標を取得している
            moveDistance += moveSpeed /3.6f * Time.deltaTime;//
            transform.position = pathCreator.path.GetPointAtDistance(moveDistance, EndOfPathInstruction.Stop);
            transform.rotation = pathCreator.path.GetRotationAtDistance(moveDistance, EndOfPathInstruction.Stop);//アセット提供のメソッド：経路上のどこにいても進行方向を向くように設定
            
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rb.velocity = Vector3.zero;
            moveSpeed = 0f;
            if (!human)
            {
                human = true;
            }
        }
        if (Taikosya1.Rstart || Taikosya2.Rstart)//対向車が停止したら
        {
            
            while(moveSpeed < SlowSpeed){
                moveSpeed += 0.001f; //徐々に動き出す
            }
            human = false;
            if(moveSpeed > 9.0f){
                Honda_Start = true;
            }
            
        }

    }

  
/*
    void OnTriggerStay(Collider collider)//コライダに当たっている間のみ表現のオンオフができるようにする
    {
        if (collider.gameObject.tag == "CurveTarget")
        {
            moveSpeed = SlowSpeed /3.6f*Time.deltaTime;


        }

    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "ResetTarget")
        {
            moveSpeed = StartSpeed / 3.6f * Time.deltaTime;


        }

    }
    */

}