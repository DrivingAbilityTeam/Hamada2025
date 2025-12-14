using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpeed_senkosya2 : MonoBehaviour
{
    
    public static bool slowmode = false;
    public static bool restart = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider collider)//箱を通過したら速度が変化する
    {
        
        if (collider.gameObject.tag == "Kosaten_Senkosya")
        {
            slowmode = true;
            restart = false;
            //通過したボックスを消す
            collider.gameObject.SetActive(false);
        }
        if (collider.gameObject.tag == "KosatenOut_Senkosya")
        {
            restart = true;
            slowmode = false;
            //通過したボックスを消す
            collider.gameObject.SetActive(false);

        }


    }
}
