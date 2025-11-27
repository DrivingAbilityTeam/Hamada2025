using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class HumanHit : MonoBehaviour
{
    
    [SerializeField]Transform Human;
    public static bool HB;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider){
        
        if(collider.gameObject.tag == "HazardTarget"){
                HB = true;
        }
    }
}
