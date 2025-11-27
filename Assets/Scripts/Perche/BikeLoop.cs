using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BikeLoop : MonoBehaviour
{
   
    [SerializeField] Transform Car;//ループする対象物を指定
    [SerializeField] Transform LoopCube;//再出現する場所をキューブのpositionで指定する。
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      
    }
    void OnTriggerEnter(Collider collider)//箱を通過したらループする
    {
        if (collider.gameObject.tag == "CarLoop")
        {
           
            //車がループする
            Car.transform.localPosition = LoopCube.transform.localPosition;

        }

    }
}
