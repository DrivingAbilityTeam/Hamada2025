using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CarLoop3 : MonoBehaviour
{
    public enum Loop_position
    {
        Loop_Left,
        Loop_Right,
        Loop_L_Back,
        Loop_R_Back,
        Human_front
    }
    [SerializeField] private Loop_position loop_position = Loop_position.Loop_Left;
    Vector3 Loop_L = new Vector3(111.8f, 0.0005f, 90f);
    Vector3 Loop_R = new Vector3(115.56f, 0.0005f, 90f);
    Vector3 Loop_L_B = new Vector3(111.8f, 0.0005f, 110f);
    Vector3 Loop_R_B = new Vector3(115.56f, 0.0005f, 110f);
    Vector3 Human_Front;
    Vector3 Loop;


    [SerializeField] Transform Car;
    // Start is called before the first frame update
    void Start()
    {
        Human_Front = this.gameObject.transform.position;

        switch (loop_position)
        {
            case Loop_position.Loop_Left:
                Loop = Loop_L;
                break;

            case Loop_position.Loop_Right:
                Loop = Loop_R;
                break;

            case Loop_position.Loop_L_Back:
                Loop = Loop_L_B;
                break;

            case Loop_position.Loop_R_Back:
                Loop = Loop_R_B;
                break;

            case Loop_position.Human_front:
                Loop = Human_Front;
                break;
        }
    }

        // Update is called once per frame
        void Update()
    {
      
    }
    void OnTriggerEnter(Collider collider)//箱を通過したらループする
    {
        if (collider.gameObject.tag == "CarLoop")
        {
        
            //車がループする
            Car.transform.localPosition = Loop;

        }

    }
}
