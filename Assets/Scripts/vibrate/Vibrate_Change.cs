using UnityEngine;
using System.Net.Sockets;
using System.Text;
using System.Collections;

public class Vibrate_Change : MonoBehaviour
{
    public enum TaskType
    {
        All, Sequence, HeartSensorFeedback, SpeedUp_Sequence, SpeedUp_All, VolumeUp_Sequence, VolumeUp_All, Heart_MP3, Heart_MP3_SpeedUp
    }

    [System.Serializable]
    public class VibrationPattern
    {
        public string name = "Pattern";
        public TaskType task_type;
        public int patternType;

        [Range(0.1f, 5f)] public float uptime = 1.0f;
        [Range(0.1f, 5f)] public float downtime = 1.0f;
        [Range(0, 100)] public int duty = 80;
        [Range(0, 5.0f)] public float scale = 0.2f;
        [Range(0, 5.0f)] public float vibe_speedup = 0.2f;
        [Range(0, 5.0f)] public float duty_up = 10;
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
            case TaskType.All: return 0;
            case TaskType.Sequence: return 1;
            case TaskType.HeartSensorFeedback: return 2;
            case TaskType.SpeedUp_Sequence: return 3;
            case TaskType.SpeedUp_All: return 4;
            case TaskType.VolumeUp_Sequence: return 5;
            case TaskType.VolumeUp_All: return 6;
            case TaskType.Heart_MP3: return 7;
            case TaskType.Heart_MP3_SpeedUp: return 8;
            default: return 0;
        }
    }

    private void SendSettings(bool stop)
    {
        if (udpClient == null)
            udpClient = new UdpClient();

        VibrationSettings settings = new VibrationSettings(
            currentPattern.patternType,
            currentPattern.uptime,
            currentPattern.downtime,
            currentPattern.duty,
            stop,
            currentPattern.scale,
            currentPattern.vibe_speedup,
            currentPattern.duty_up
        );

        string json = JsonUtility.ToJson(settings);
        byte[] data = Encoding.UTF8.GetBytes(json);
        udpClient.Send(data, data.Length, raspberryPiIP, port);

        Debug.Log("送信データ: " + json);
    }

    [System.Serializable]
    public class VibrationSettings
    {
        public int pattern;
        public float uptime;
        public float downtime;
        public int duty;
        public bool stop;
        public float scale;
        public float vibeaccel;
        public float volumeup;

        public VibrationSettings(int p, float u_t, float d_t, int d, bool s, float vibescale, float vibespeed, float volume)
        {
            pattern = p;
            uptime = u_t;
            downtime = d_t;
            duty = d;
            stop = s;
            scale = vibescale;
            vibeaccel = vibespeed;
            volumeup = volume;
        }
    }
}
