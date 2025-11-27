using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HumanMove : MonoBehaviour
{
    bool isDead = false;
    bool isWalk = false;
    bool isCollision = false;
    float impulse = 25;

    Animation animation;
    Rigidbody rigidBody;
    Rigidbody CarRigidBody;
    CapsuleCollider capsuleCollider;
    BoxCollider boxCollider;
    GameObject Car;

    void Start()
    {
        //歩行者のコンポーネントを取得
        animation = GetComponent<Animation>();
        rigidBody = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        boxCollider = GetComponent<BoxCollider>();

        //車をタグで検索し、Rigidbodyを取得
        Car = GameObject.FindGameObjectWithTag("Player");
        CarRigidBody = Car.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        //車と接触したら倒れる
        //一度倒れたらこの処理はしない
        if (collision.gameObject.tag == "Player" && isCollision == false)
        {
                //倒れないようにしているのを解除
                rigidBody.freezeRotation = false;

                //吹っ飛ばす
                Vector3 HumanVelocity = CarRigidBody.velocity;
                rigidBody.AddForce(HumanVelocity * impulse, ForceMode.Impulse);
                rigidBody.AddForce(Vector3.up * impulse, ForceMode.Impulse);

                //コライダーを切り替え
                capsuleCollider.enabled = false;
                boxCollider.enabled = true;

                
                isCollision = true;
        
            
        }
    }

}




