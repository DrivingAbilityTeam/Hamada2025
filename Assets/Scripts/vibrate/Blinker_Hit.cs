using UnityEngine;

public class Blinker_Hit : MonoBehaviour
{
    // -----------------------
    // �E�B���J�[���[�h
    // -----------------------
    public enum TurnMode
    {
        Left,
        Right
    }

    [Header("�E�B���J�[�ݒ�")]
    [SerializeField] private TurnMode turnMode;

    [SerializeField] private GameObject leftBlinker;
    [SerializeField] private GameObject rightBlinker;

    private void Start()
    {
        // ������Ԃł͗���OFF
        if (leftBlinker != null) leftBlinker.SetActive(false);
        if (rightBlinker != null) rightBlinker.SetActive(false);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "blinker")
        {
            ActivateBlinker();
            //通過したボックスを消す
            collider.gameObject.SetActive(false);
        }
        if (collider.gameObject.tag == "blinker_off")
        {
            
            NotactivateBlinker();
            //通過したボックスを消す
            collider.gameObject.SetActive(false);

        }
    }

    private void ActivateBlinker()
    {
        if (turnMode == TurnMode.Left)
        {
            if (leftBlinker != null) leftBlinker.SetActive(true);
            if (rightBlinker != null) rightBlinker.SetActive(false);
        }
        else if (turnMode == TurnMode.Right)
        {
            if (rightBlinker != null) rightBlinker.SetActive(true);
            if (leftBlinker != null) leftBlinker.SetActive(false);
        }
    }

    private void NotactivateBlinker()
    {
        if (turnMode == TurnMode.Left)
        {
            if (leftBlinker != null) leftBlinker.SetActive(false);
            if (rightBlinker != null) rightBlinker.SetActive(false);
        }
        else if (turnMode == TurnMode.Right)
        {
            if (rightBlinker != null) rightBlinker.SetActive(false);
            if (leftBlinker != null) leftBlinker.SetActive(false);
        }
    }
}
