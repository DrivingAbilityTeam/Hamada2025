using UnityEngine;
using System.Net.Sockets;
using System.Text;
using System.Collections;

public class Vibrate_Change3 : MonoBehaviour
{
    public enum TaskType
    {
        All_change, All_change2, Right_front, Right_front2, Left_front, Left_front2, Foot
    }

    [System.Serializable]
    public class VibrationPattern
    {
        public string name = "Pattern";
        public TaskType task_type;
        public int patternType;
    }

    [Header("Network Settings")]
    public string raspberryPiIP = "192.168.11.36";
    public int port = 5005;

    [Header("Vibration Patterns (2 patterns)")]
    public VibrationPattern[] patterns = new VibrationPattern[2]; // インスペクタで2つ指定可能

    private UdpClient udpClient;
    private VibrationPattern currentPattern;
    private bool isVibrating = false;
    public static bool vibrate_status = false;//saveFunction3用

    void Start()
    {
        udpClient = new UdpClient();
        if (patterns.Length > 0)
        {
            SetPattern(0); // 最初のパターンを初期化
        }
    }

    /// <summary>
    /// ボックスに触れたときに呼ばれる
    /// </summary>
    void OnTriggerEnter(Collider other)
    {
        if (!this.enabled) { return; } //スクリプトを非アクティブにしてもトリガーは有効なため、この一行を入れる
        if (other.CompareTag("Vibration_Start"))
        {
            StartCoroutine(StartPattern(0));
            other.gameObject.SetActive(false);
            vibrate_status = true;
        }
        else if (other.CompareTag("Vibration_Change"))
        {
            StartCoroutine(StartPattern(1));
            other.gameObject.SetActive(false);
        }
        else if (other.CompareTag("Vibration_Change2"))
        {
            StartCoroutine(StartPattern(2));
            other.gameObject.SetActive(false);
        }
        else if (other.CompareTag("Vibration_Stop"))
        {
            StopVibration();
            other.gameObject.SetActive(false);
            vibrate_status = false;
        }

        //Debug.Log(" other name " + other.name);
    }
    

    private IEnumerator StartPattern(int index)
    {

        SendSettings(true);
        yield return new WaitForSeconds(1f);
       

        currentPattern = patterns[index];
        currentPattern.patternType = GetPatternTypeFromTaskType(currentPattern.task_type);

        SendSettings(false);

        //Debug.Log(" start pattern " +  index);
        
        
        
    }

    private void StopVibration()
    {
            SendSettings(true);

            //Debug.Log(" Stopppppppp");
            
    }

    private void SetPattern(int index)
    {


        if (index < 0 || index >= patterns.Length)
            return;

        currentPattern = patterns[index];
        currentPattern.patternType = GetPatternTypeFromTaskType(currentPattern.task_type);
    }

    private int GetPatternTypeFromTaskType(TaskType taskType)
    {
        switch (taskType)
        {
            case TaskType.All_change: return 0;
            case TaskType.All_change2: return 1;
            case TaskType.Right_front: return 2;
            case TaskType.Right_front2: return 3;
            case TaskType.Left_front: return 4;
            case TaskType.Left_front2: return 5;
            case TaskType.Foot: return 6;
            default: return 0;
        }
    }

    private void SendSettings(bool stop)
    {
        if (udpClient == null)
            udpClient = new UdpClient();

        VibrationSettings settings = new VibrationSettings(
            currentPattern.patternType,
            stop
        );

        string json = JsonUtility.ToJson(settings);
        byte[] data = Encoding.UTF8.GetBytes(json);
        udpClient.Send(data, data.Length, raspberryPiIP, port);

        Debug.Log("送信データ: " + json);
    }

    [System.Serializable]
    public class VibrationSettings
    {
        public int Pattern;
        public bool stop;

        public VibrationSettings(int p, bool s)
        {
            Pattern = p;
            stop = s;
        }
    }
}
