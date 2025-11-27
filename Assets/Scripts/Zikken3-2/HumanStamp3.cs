using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HumanStamp3 : MonoBehaviour
{  
    
    [SerializeField] GameObject Hyogen;
    [SerializeField] GameObject Carframe;
    Renderer CarframeMaterial;

    public Material spe_material;

    // Start is called before the first frame update
    void Start()
    {
        
        CarframeMaterial = Carframe.GetComponent<MeshRenderer>();
        Hyogen.SetActive(false);
        CarframeMaterial.sharedMaterial.DisableKeyword("_EMISSION");

    }

    // Update is called once per frame
    void Update()
    {
        

        if (HumanHit.HB)
        {
            CarframeMaterial.material = spe_material;

            CarframeMaterial.sharedMaterial.EnableKeyword("_EMISSION");
            Hyogen.SetActive(true);

        }

    }

}