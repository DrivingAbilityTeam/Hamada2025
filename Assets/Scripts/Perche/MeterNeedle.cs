using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class MeterNeedle : MonoBehaviour
{

    public Transform Needle;

    public Movement_Base_Logitec movement_base;
    
    // 針の動きをスムーズにするためのダンピング速度
    [SerializeField] private float smoothing = 10f;
    private float currentVelocity = 0f;  // SmoothDamp 用の現在の速度

   
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Needle == null) return;
        

        

        float velo = movement_base.moveSpeed;
        Vector3 localAngle = Needle.eulerAngles;
        float angleScale = -169f / 100f;
        float targetAngle = velo * angleScale ;

        localAngle.z = Mathf.SmoothDampAngle(localAngle.z, targetAngle, ref currentVelocity, smoothing);
        Needle.eulerAngles = localAngle;
    }
}

