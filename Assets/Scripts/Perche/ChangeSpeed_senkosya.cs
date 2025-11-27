using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpeed_senkosya : MonoBehaviour
{
    public static bool hit;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider collider)//” ‚ð’Ê‰ß‚µ‚½‚ç‘¬“x‚ª•Ï‰»‚·‚é
    {
        
        if (collider.gameObject.tag == "Kosaten")
        {
            hit = true;
        }

        

    }
}
