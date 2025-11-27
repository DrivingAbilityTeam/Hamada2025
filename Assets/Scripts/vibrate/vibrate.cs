using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class vibrate : MonoBehaviour
{
    public enum TaskType
    {
        All, Sequence, HeartSensorFeedback, SpeedUp_Sequence, SpeedUp_All, VolumeUp_Sequence, VolumeUp_All
    }

    [Header("Vibration Settings")]

    public TaskType task_type;

    public int patternType;

    [Range(0.1f, 5f)]
    public float uptime = 1.0f;

    [Range(0.1f, 5f)]
    public float downtime = 1.0f;

    [Range(0, 100)]
    public int duty = 80;

    [Range(0, 5.0f)]
    public float scale = 0.2f;

    [Range(0, 5.0f)]
    public float vibe_speedup = 0.2f;

    [Range(0, 5.0f)]
    public float duty_up = 10;

    [Header("Network Settings")]
    public string raspberryPiIP = "192.168.11.36";
    public int port = 5005;

    private UdpClient udpClient;
    

    void Start()
    {
        udpClient = new UdpClient();
        Debug.Log("VibrationSender is ready. Press [V] to send settings.");

        if (task_type == TaskType.All)
        {
            patternType = 0;
        }

        if (task_type == TaskType.Sequence)
        {
            patternType = 1;
        }

        if (task_type == TaskType.HeartSensorFeedback)
        {
            patternType = 2;
        }

        if (task_type == TaskType.SpeedUp_Sequence)
        {
            patternType = 3;
        }

        if (task_type == TaskType.SpeedUp_All)
        {
            patternType = 4;
        }
        if (task_type == TaskType.VolumeUp_Sequence)
        {
            patternType = 5;
        }

        if (task_type == TaskType.VolumeUp_All)
        {
            patternType = 6;
        }
    }

    void Update()
    {
        // �L�[�{�[�h�ő��M���g���K�[�i��: V�L�[�j
        if (Input.GetKeyDown(KeyCode.V))
        {
            SendSettings(false);
        }

        // �X�g�b�v�iS�L�[�j
        if (Input.GetKeyDown(KeyCode.S))
        {
            SendSettings(true);  // ��~�w�߂𑗂�
        }
        
       

    }

    void SendSettings(bool stop)
    {
        VibrationSettings settings = new VibrationSettings(patternType, uptime, downtime, duty, stop, scale, vibe_speedup, duty_up);
        string json = JsonUtility.ToJson(settings);
        byte[] data = Encoding.UTF8.GetBytes(json);

        udpClient.Send(data, data.Length, raspberryPiIP, port);

        Debug.Log("���M�f�[�^: " + json);
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
