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

    [SerializeField] private GameObject HumanGroupB;
    [SerializeField] private GameObject HumanGroupC;
    [SerializeField] private GameObject HumanGroupD;

    [Header("êÊçsé‘ÇÃON / OFF")]
    [SerializeField] private bool Senkosya_mode = true;
    [SerializeField] private GameObject SenkosyaObject;


    private void ApplyActiveState()
    {
        if (SenkosyaObject != null)
        {
            SenkosyaObject.SetActive(Senkosya_mode);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ApplyActiveState();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Curve_Hit.Curve_In == 1)
        {
            CarGroupB.SetActive(true);
            CarGroupA.SetActive(false);
            HumanGroupB.SetActive(true);
            HeikousyaGroupB.SetActive(true);
            
        }
        if (Curve_Hit.Curve_In == 2)
        {
            CarGroupC.SetActive(true);
            CarGroupB.SetActive(false);
            HumanGroupB.SetActive(false);
            HumanGroupC.SetActive(true);
            HeikousyaGroupB.SetActive(false);
            HeikousyaGroupC.SetActive(true);
        }
        if (Curve_Hit.Curve_In == 3)
        {
            CarGroupD.SetActive(true);
            CarGroupC.SetActive(false);
            HumanGroupC.SetActive(false);
            HumanGroupD.SetActive(true);
            HeikousyaGroupC.SetActive(false);
            HeikousyaGroupD.SetActive(true);
        }
        

    }

}
