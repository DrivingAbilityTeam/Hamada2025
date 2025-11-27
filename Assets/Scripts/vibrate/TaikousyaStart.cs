using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TaikousyaStart : MonoBehaviour
{

    [SerializeField] private GameObject CarGroupA;
    [SerializeField] private GameObject CarGroupB;
    [SerializeField] private GameObject CarGroupC;
    [SerializeField] private GameObject CarGroupD;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Curve_Hit.Curve_In == 1)
        {
            CarGroupB.SetActive(true);
            CarGroupA.SetActive(false);
        }
        if (Curve_Hit.Curve_In == 2)
        {
            CarGroupC.SetActive(true);
            CarGroupB.SetActive(false);
        }
        if (Curve_Hit.Curve_In == 3)
        {
            CarGroupD.SetActive(true);
            CarGroupC.SetActive(false);
        }
        

    }

}
