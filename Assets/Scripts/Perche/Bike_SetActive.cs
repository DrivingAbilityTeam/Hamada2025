using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Bike_SetActive : MonoBehaviour
{

    [SerializeField] private GameObject Bike;

    public static bool hb;
    public static bool Bike_status = false;
    public bool bike_status = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Hit_Bike.bike_Active)//初めにバイクが出現したタイミングを記録
        {
            hb = true;
            Bike.SetActive(true);
           

            Bike_status = true;//Bike_Distanceで呼び出す用
            bike_status = true;
            
        }
        if (Bike_move.bike_roop)//バイクが再び出現したタイミングを記録
        {
            hb = true;
            Bike.SetActive(true);

            bike_status = true;
            

        }
    }

}
