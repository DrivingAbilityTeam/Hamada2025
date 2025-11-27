using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLights1 : MonoBehaviour
{
    // Start is called before the first frame update
    Renderer BlueMaterial;
    Renderer YellowMaterial;
    Renderer RedMaterial;

    //Renderer material;

    Vector3 tlP;
    Vector3 TagetP;

    float distanceZ;
    float countTime;

    [SerializeField] private GameObject TagetGet;
    [SerializeField] private GameObject tlGet;

    [SerializeField] private GameObject BlueGet;
    [SerializeField] private GameObject YellowGet;
    [SerializeField] private GameObject RedGet;
    [SerializeField] private float Distance;

    void Start()
    {
        BlueMaterial = BlueGet.GetComponent<MeshRenderer>();
        YellowMaterial = YellowGet.GetComponent<MeshRenderer>();
        RedMaterial = RedGet.GetComponent<MeshRenderer>();

        BlueMaterial.sharedMaterial.EnableKeyword("_EMISSION");//元々参照のあるMaterialをそのまま返却する。EMISSIONは発光のオンオフ切り替えキーワード
        YellowMaterial.sharedMaterial.DisableKeyword("_EMISSION");
        RedMaterial.sharedMaterial.DisableKeyword("_EMISSION");
    }

    // Update is called once per frame
    void Update()
    {
        TagetP = TagetGet.transform.position;
        tlP = tlGet.transform.position;
 
        distanceZ = TagetP.z - tlP.z;

        if (countTime<= 3.0 && distanceZ < Distance)
        {
            countTime += Time.deltaTime;
            BtoY();//青から黄色へ
        }
        if (countTime > 3.0f)
        {
            YtoR();//黄色から赤へ
        }
            /*
            i = 0;

            if(distanceZ < 0){
                i = 1;
            }if(i == 1)
            {
                BtoY();
                Invoke("YtoR", 1.0f);
                i = 2;
            }
            */
    }

    private void BtoY()
    {
        BlueMaterial.sharedMaterial.DisableKeyword("_EMISSION");
        YellowMaterial.sharedMaterial.EnableKeyword("_EMISSION");
    }

    private void YtoR()
    {
        YellowMaterial.sharedMaterial.DisableKeyword("_EMISSION");
        RedMaterial.sharedMaterial.EnableKeyword("_EMISSION");
    }

}
