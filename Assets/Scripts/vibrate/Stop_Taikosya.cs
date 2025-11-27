using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Stop_Taikosya : MonoBehaviour
{
    [SerializeField] private float CarSpeed;//初期速度
    [SerializeField] private float SlowSpeed;
    [SerializeField] Transform Car;

    private bool Stop_Car = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

        if(Stop_Car){
            
            CarSpeed -= SlowSpeed*Time.deltaTime;
            if (CarSpeed < 0) 
            {
                CarSpeed = 0;
            }
            
        }
        transform.position += transform.forward * (CarSpeed / 3.6f * Time.deltaTime);



    }
    void OnTriggerEnter(Collider collider)
    {

        if (collider.gameObject.tag == "Stop_Kosaten")
        {
            Stop_Car = true;
            //通過したボックスを消す
            collider.gameObject.SetActive(false);

        }
    }

}