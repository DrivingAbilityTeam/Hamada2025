using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Bike_SetAc : MonoBehaviour
{

    [SerializeField] private GameObject BikeA;
    [SerializeField] private GameObject BikeB;
    [SerializeField] private GameObject BikeC;
    [SerializeField] private GameObject BikeD;

    public static bool bike_A_status = false;
    public static bool bike_B_status = false;
    public static bool bike_C_status = false;
    public static bool bike_D_status = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Bike_Hit.bike_Active == 1 && BikeA != null)//���߂Ƀo�C�N���o�������^�C�~���O���L�^
        {
            BikeA.SetActive(true);
            bike_A_status = true;   
        }

        if (Bike_Hit.bike_Active == 2 && BikeA != null)//���߂Ƀo�C�N���o�������^�C�~���O���L�^
        {
            BikeA.SetActive(false);
            bike_A_status = false;
        }

        if (Bike_Hit.bike_Active == 2 && BikeB != null)//���߂Ƀo�C�N���o�������^�C�~���O���L�^
        {
            
            BikeB.SetActive(true);
            bike_B_status = true;
        }

        if (Bike_Hit.bike_Active == 3 && BikeB != null)//���߂Ƀo�C�N���o�������^�C�~���O���L�^
        {
            BikeB.SetActive(false);
            bike_B_status = false;
        }

        if (Bike_Hit.bike_Active == 3 && BikeC != null)//���߂Ƀo�C�N���o�������^�C�~���O���L�^
        {
            BikeC.SetActive(true);
            bike_C_status = true;
        }

        if (Bike_Hit.bike_Active == 4 && BikeC != null)//���߂Ƀo�C�N���o�������^�C�~���O���L�^
        {
            BikeC.SetActive(false);
            bike_C_status = false;

        }

        if (Bike_Hit.bike_Active == 4 && BikeD != null)//���߂Ƀo�C�N���o�������^�C�~���O���L�^
        {
            BikeD.SetActive(true);
            bike_D_status = true;
        }


    }

}
