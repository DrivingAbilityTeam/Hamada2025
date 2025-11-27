using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CarLoop2 : MonoBehaviour
{
   
    [SerializeField] Transform Car;
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
            Car.transform.localPosition = new Vector3(111.8f, 0.0005f, 115f);

        }

    }
}
