using UnityEngine;

public class Alert_Hit : MonoBehaviour
{
    public AudioClip sound1;
    AudioSource audioSource;//Audioソース型の変数

    [SerializeField] private GameObject Alert_icon;
    private bool Alert_on;
    private void Start()
    {
        if (Alert_icon != null) Alert_icon.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Alert_on)
        {
            audioSource.PlayOneShot(sound1);//交差点アラートが鳴る
            
        }
        if (!Alert_on)
        {
            audioSource.Stop();
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
