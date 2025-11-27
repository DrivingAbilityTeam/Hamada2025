using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HumanStart : MonoBehaviour
{
    public enum HazardType
    {
        Human_F,
        Human_B,
        Bike,
    }
    [SerializeField] private HazardType hazardType = HazardType.Human_F;
    private GameObject Hazard;
    [SerializeField] private GameObject human_F;
    [SerializeField] private GameObject human_B;
    [SerializeField] private GameObject bike;
    public static bool hb;
    // Start is called before the first frame update
    void Start()
    {
       switch (hazardType)
        {
            case HazardType.Human_F:
                Hazard = human_F;
                break;

            case HazardType.Human_B:
                Hazard = human_B;
                break;

            case HazardType.Bike:
                Hazard = bike;
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
      if(Taikosya1.stop || Taikosya2.stop){
        hb = true;
        Hazard.SetActive(true);
        
      }
    }
   
}