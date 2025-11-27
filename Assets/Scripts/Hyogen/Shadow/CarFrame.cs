using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarFrame : MonoBehaviour
{
    //float fadeSpeed = 0.01f; 
    [SerializeField] float fadeSpeed;
    float red, green, blue, alfa;   

    public bool isFadeOut = false;  
    public bool isFadeIn = false;   

    Renderer fadeMaterial;    

    //Vector3 BikeP;
    Vector3 CarP;
    Vector3 TagetP;

    float distanceZ;

    [SerializeField] private GameObject BikeGet;
    [SerializeField] private GameObject CarGet;
    [SerializeField] private float StartIn;
    [SerializeField] private float StartOut;
    double b;

    // Start is called before the first frame update
    void Start()
    {
        fadeMaterial = GetComponent<Renderer>();
        red = fadeMaterial.material.color.r;
        green = fadeMaterial.material.color.g;
        blue = fadeMaterial.material.color.b;
        alfa = fadeMaterial.material.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFadeIn)
        {
            StartFadeIn(); 
        }
        if (isFadeOut)
        {
            StartFadeOut(); 
        }

        // BikeP = GameObject.Find("BikePoint").transform.position;

        TagetP = BikeGet.transform.position;
        CarP = CarGet.transform.position;
        //distanceZ = BikeP.z - CarP.z;
        distanceZ = TagetP.z - CarP.z;

        if (distanceZ <= StartIn)
        {
            b = 1;
            if (b == 1)
            {
                isFadeIn = true;
                
                //Debug.Log("FLOW");
            }
        }
        if (distanceZ < StartOut)
        {
            b = 2;
            if (b == 2)
            {
                isFadeIn = false;
                isFadeOut = true;
            }
        }

    }
    void StartFadeOut()
    {
        alfa -= fadeSpeed;         
        SetAlpha();             
        if (alfa <= 0)          
        {
            isFadeOut = false;    
            fadeMaterial.enabled = false;  
        }
    }
    void StartFadeIn()
    {
        fadeMaterial.enabled = true; 
        alfa += fadeSpeed;         
        SetAlpha();              
        if (alfa >= 1)              
        {
            isFadeIn = false;      
        }
    }
    void SetAlpha()
    {
        fadeMaterial.material.color = new Color(red, green, blue, alfa);
        
    }
}
