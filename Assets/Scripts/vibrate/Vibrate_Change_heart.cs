using UnityEngine;
using System.Net.Sockets;
using System.Text;
using System.Collections;

public class Vibrate_Change_heart : MonoBehaviour
{
    public enum TaskType
    {
        Normal_Heartvibe, Accel_Heartvibe
    }

    [System.Serializable]
    public class VibrationPattern
    {
        public string name = "Pattern";
        public TaskType task_type;
        public int patternType;
    }

    [Header("Network Settings")]
    public string raspberryPiIP = "192.168.11.55";
    public int port = 5005;

    [Header("Vibration Patterns (2 patterns)")]
    public VibrationPattern[] patterns = new VibrationPattern[2]; // インスペクタで2つ指定可能

    private UdpClient udpClient;
    private VibrationPattern currentPattern;
    public static bool Heart_accel = false;//saveFunction3用

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
        if (other.CompareTag("Vibration_Start"))
        {
            StartCoroutine(StartPattern(0));
            other.gameObject.SetActive(false);
            Heart_accel = true;
        }
        else if (other.CompareTag("Vibration_Change"))
        {
            StartCoroutine(StartPattern(1));
            other.gameObject.SetActive(false);
        }
        else if (other.CompareTag("Vibration_Stop"))
        {
            StopVibration();
            other.gameObject.SetActive(false);
            Heart_accel = false;
        }

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
            case TaskType.Normal_Heartvibe: return 0;
            case TaskType.Accel_Heartvibe: return 1;
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
