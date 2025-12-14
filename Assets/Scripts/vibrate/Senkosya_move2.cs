using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Senkosya_move2 : MonoBehaviour
{
    [SerializeField] PathCreator pathCreator;
    public float moveSpeed;
    [SerializeField] GameObject car;
    [SerializeField] private float SlowSpeed;

    private bool human = false;
    private Rigidbody rb;

    public static bool Honda_Start;

    Vector3 endPos;

    float moveDistance;

    //速度変更したい場合
    [SerializeField] private bool ChangeMode;
    [SerializeField] private float ChangeSpeed1;
    [SerializeField] private float ChangeSpeed2;


    void Start()
    {
        moveSpeed = SlowSpeed;
        endPos = pathCreator.path.GetPoint(pathCreator.path.NumPoints - 1);//アセット提供のメソッドを使用：最終地点の座標を取得（経路上の点の数 ー１）
        rb = car.GetComponent<Rigidbody>();  // rigidbodyを取得
    }

    void Update()
    {

        if (!human)//通常時
        {
            //開始地点からの経路上の距離を指定し点の座標を取得している
            moveDistance += moveSpeed / 3.6f * Time.deltaTime;//
            transform.position = pathCreator.path.GetPointAtDistance(moveDistance, EndOfPathInstruction.Stop);
            transform.rotation = pathCreator.path.GetRotationAtDistance(moveDistance, EndOfPathInstruction.Stop);//アセット提供のメソッド：経路上のどこにいても進行方向を向くように設定

        }


        if (ChangeSpeed_senkosya2.slowmode)//減速
        {

            float SpeedGap = ChangeSpeed1 - moveSpeed;
            moveSpeed += SpeedGap * 1.1f * Time.deltaTime; // 補間スピードは調整可

        }
        else if (ChangeSpeed_senkosya2.restart)//加速
        {

            moveSpeed += 10f * Time.deltaTime;

            if (moveSpeed > SlowSpeed)
            {
                moveSpeed = SlowSpeed;
            }

        }


    }

}
