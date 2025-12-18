using UnityEngine;
using System.Collections;

public class Alert_Hit : MonoBehaviour
{
    public AudioClip sound1;
    AudioSource audioSource;//Audioソース型の変数

    [SerializeField] private GameObject Alert_icon;
    private bool Alert_on = false;
    private bool Alert_wait = false;
    private int i=0;

    IEnumerator Alert_Audio()
    {
        Debug.Log("開始");
        while (Alert_on) {
            i++;
            audioSource.PlayOneShot(sound1);//交差点アラートが鳴る
            yield return new WaitForSeconds(1.15f/i);
        }           
 
        Debug.Log("さらに2秒経過");
    }

    private void Start()
    {
        if (Alert_icon != null) Alert_icon.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Alert_on&&!Alert_wait)
        {
            StartCoroutine(Alert_Audio());
            Alert_wait = true;
        }
        if (!Alert_on)
        {
            audioSource.Stop();
            i = 0;
            Alert_wait = false;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (!this.enabled) { return; } //スクリプトを非アクティブにしてもトリガーは有効なため、この一行を入れる
        if (collider.gameObject.tag == "Alert_Hit")
        {
            if (Alert_icon != null) Alert_icon.SetActive(true);
            Alert_on = true;
            //通過したボックスを消す
            collider.gameObject.SetActive(false);
        }
        if (collider.gameObject.tag == "Alert_off")
        {
            if (Alert_icon != null) Alert_icon.SetActive(false);
            Alert_on = false;
            //通過したボックスを消す
            collider.gameObject.SetActive(false);

        }
    }

}
