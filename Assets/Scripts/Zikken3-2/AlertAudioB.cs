using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AlertAudioB : MonoBehaviour
{
    public AudioClip sound1;
    AudioSource audioSource;//Audio�\�[�X�^�̕ϐ�


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
                  
            if(HumanHit.HB){
                audioSource.PlayOneShot(sound1);//�n�U�[�h�ڋ߂�����A���[�g����
            }
        
    }

}
