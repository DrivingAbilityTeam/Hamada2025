using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLights2 : MonoBehaviour
{
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
    [SerializeField] private float Diatance;
   // Start is called before the first frame update
    void Start()
    {
        BlueMaterial = BlueGet.GetComponent<MeshRenderer>();
        YellowMaterial = YellowGet.GetComponent<MeshRenderer>();
        RedMaterial = RedGet.GetComponent<MeshRenderer>();

        BlueMaterial.sharedMaterial.DisableKeyword("_EMISSION");
        YellowMaterial.sharedMaterial.DisableKeyword("_EMISSION");
        RedMaterial.sharedMaterial.EnableKeyword("_EMISSION");
    }

    // Update is called once per frame
    void Update()
    {
        TagetP = TagetGet.transform.position;
        tlP = tlGet.transform.position;
 
        distanceZ = TagetP.z - tlP.z;

        if (countTime<= 3.0 && distanceZ < Diatance)
        {
            countTime += Time.deltaTime;
            RtoY();
        }
        if (countTime > 3.0f)
        {
            YtoB();
        }
      
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

    private void RtoY()
    {
        RedMaterial.sharedMaterial.DisableKeyword("_EMISSION");
        YellowMaterial.sharedMaterial.EnableKeyword("_EMISSION");
    }

    private void YtoB()
    {
        YellowMaterial.sharedMaterial.DisableKeyword("_EMISSION");
        BlueMaterial.sharedMaterial.EnableKeyword("_EMISSION");
    }

}
