using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class AlertB : MonoBehaviour
{

    [SerializeField] GameObject Alert;


    // Start is called before the first frame update
    void Start()
    {
        Alert.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(HumanHit.HB){
                Alert.SetActive(true);
        }
    }
}
