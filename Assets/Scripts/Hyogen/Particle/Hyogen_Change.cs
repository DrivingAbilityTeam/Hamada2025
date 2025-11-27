using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Hyogen_Change : MonoBehaviour
{
    public enum HyogenType
    {
        Hyogen_0,
        Hyogen_1,
        Hyogen_2,
        Hyogen_3,
        Hyogen_4,
        Hyogen_5,
        Hyogen_6,
        Hyogen_7,
    }
    [SerializeField] private HyogenType RedType = HyogenType.Hyogen_0;
    public GameObject[] signs;
    private GameObject Hyogen;

    // Start is called before the first frame update
    void Start()
    {
        switch (RedType)
        {
            case HyogenType.Hyogen_0:
                Hyogen = signs[0];
                break;

            case HyogenType.Hyogen_1:
                Hyogen = signs[1];
                break;

            case HyogenType.Hyogen_2:
                Hyogen = signs[2];
                break;

            case HyogenType.Hyogen_3:
                Hyogen = signs[3];
                break;

            case HyogenType.Hyogen_4:
                Hyogen = signs[4];
                break;

            case HyogenType.Hyogen_5:
                Hyogen = signs[5];
                break;

            case HyogenType.Hyogen_6:
                Hyogen = signs[6];
                break;

            case HyogenType.Hyogen_7:
                Hyogen = signs[7];
                break;
        }

        Hyogen.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.JoystickButton2)){

            Debug.Log("Yeah!!!");
        }
    }
}
