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

    [SerializeField] private GameObject HeikousyaGroupB;
    [SerializeField] private GameObject HeikousyaGroupC;
    [SerializeField] private GameObject HeikousyaGroupD;

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
            HeikousyaGroupB.SetActive(true);
        }
        if (Curve_Hit.Curve_In == 2)
        {
            CarGroupC.SetActive(true);
            CarGroupB.SetActive(false);
            HeikousyaGroupB.SetActive(false);
            HeikousyaGroupC.SetActive(true);
        }
        if (Curve_Hit.Curve_In == 3)
        {
            CarGroupD.SetActive(true);
            CarGroupC.SetActive(false);
            HeikousyaGroupC.SetActive(false);
            HeikousyaGroupD.SetActive(true);
        }
        

    }

}
