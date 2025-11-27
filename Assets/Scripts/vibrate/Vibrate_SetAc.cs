using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Vibrate_SetAc : MonoBehaviour
{

    [SerializeField] private GameObject Vibrate_Change;
    [SerializeField] private GameObject Vibrate_Normal;

    public static bool vibrate_status = false;
   

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Vibrate_Hit.Vibrate_Status == 1 && Vibrate_Normal!= null )
        {
            Vibrate_Normal.SetActive(true);
            
              
        }

        if (Vibrate_Hit.Vibrate_Status == 2 && Vibrate_Normal!= null && Vibrate_Change!= null)
        {
            Vibrate_Normal.SetActive(false);
            
            Vibrate_Change.SetActive(true);
            
        }
        if (Vibrate_Hit.Vibrate_Status == 0 && Vibrate_Normal!= null && Vibrate_Change!= null)
        {
            Vibrate_Normal.SetActive(false);
            
            Vibrate_Change.SetActive(false);
            
        }
    }

}
