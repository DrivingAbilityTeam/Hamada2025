using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;//CSV�ۑ����邽�߂ɕK�v
using System;//DataTime(�f�[�^�擾�̓������L�^�j���g���̂ɕK�v
using System.Text;

using System.Net;
using System.Net.Sockets;


public class saveFunction3 : MonoBehaviour
{
  private StreamWriter sw;

  private Transform _carTrans;
  private CarController _car;
  public Movement_Base_Logitec _autoCar;
  public Perche_move _perche;

  float _time;

  string format = "f4";

  int save_number;

  [SerializeField] public Rigidbody car_Rigidbody;

  public bool perche;


  [Header("Network Settings")]
  public string raspberryPiIP = "192.168.11.36";
  public int port = 5010;

  public string raspberryPi_perche_IP = "192.168.11.55";
  public int port_perche = 60001;

    private UdpClient udpClient;
    private UdpClient udpClient_perche;

    // Start is called before the first frame update
    void Start()
  {
        udpClient = new UdpClient();
        udpClient_perche = new UdpClient();
        Debug.Log("BPM_SavemodeON");

    _carTrans = GameObject.FindGameObjectWithTag("Player").transform;
    _car = _carTrans.GetComponent<CarController>();



    //excel�t�@�C�����̐擪������
    string filename = "sampleFile";

    //�t�@�C�����ɓ��t���L��
    DateTime now = DateTime.Now;

    save_number = PlayerPrefs.GetInt("Save_Number", 0);
    save_number++;
    PlayerPrefs.SetInt("Save_Number", save_number);

    filename = filename + now.Year.ToString() + "_" + now.Month.ToString() + "_" + now.Day.ToString() + "_" + now.Hour.ToString() + "_" + now.Minute.ToString() + "_" + save_number;

    sw = new StreamWriter(filename + ".csv", true, Encoding.GetEncoding("Shift_JIS"));
    string[] s1 = { "Time", "Accel", "Brake","Car_Speed", "Car_AutoSpeed", "Car_AutoStatus", "Bike_A_Status", "Bike_B_Status", "Bike_C_Status", "Bike_D_Status", "Bike_Distance","Vibrate_Status","BPM" };//�\�̈�ԏ�ɓ���鍀�ږ��������Ŏw��
    string s2 = string.Join(",", s1);//������ɋ�؂������
    sw.WriteLine(s2);

    // --- ここでBPMログ開始の信号をラズパイに送信 ---
    SendBpmCommand("log");
    SendPercheCommand("log");
    }

    public void SaveData(string txt1, string txt2, string txt3, string txt4, string txt5, string txt6, string txt7, string txt8, string txt9, string txt10, string txt11, string txt12)//�f�[�^�擾�̃I�u�W�F�N�g�ɃA�^�b�`����X�N���v�g���ŌĂяo�����֐�
    {

        string[] s1 = { txt1, txt2, txt3, txt4, txt5, txt6, txt7, txt8, txt9, txt10, txt11, txt12};
        string s2 = string.Join(",", s1);
        sw.WriteLine(s2);
        // === SaveDataタイミングでBPM記録指示を送信 ===
        SendBpmCommand("save");
        SendPercheCommand("save");
    }

    void Update()
    {
      _time += Time.deltaTime;      
      SaveData(_time.ToString(format), _car.AccelInput.ToString(format), _car.BrakeInput.ToString(format), _car.speed.ToString(format), _autoCar.moveSpeed.ToString(format), _autoCar.car_status.ToString(), Bike_SetAc.bike_A_status.ToString(), Bike_SetAc.bike_B_status.ToString(), Bike_SetAc.bike_C_status.ToString(), Bike_SetAc.bike_D_status.ToString(), Bike_Dis.disZ1.ToString(format),Vibrate_Change.vibrate_status.ToString());

      if (Input.GetKeyDown(KeyCode.Return))
      {
            Debug.Log("手動で記録停止（Enterキー）");
            SendBpmCommand("stop");
            SendPercheCommand("stop");
            sw.Close();

      }
    }
    void SendBpmCommand(string command)
    {
        try
        {
            byte[] data = Encoding.UTF8.GetBytes(command);
            udpClient.Send(data, data.Length, raspberryPiIP, port);
            Debug.Log("送信コマンド: " + command);
        }
        
        catch (Exception e)
        {
            Debug.LogWarning("UDP送信失敗: " + e.Message);
        }

    }
    void SendPercheCommand(string command)
    {
        try
        {
            byte[] data = Encoding.UTF8.GetBytes(command);
            udpClient_perche.Send(data, data.Length, raspberryPi_perche_IP, port_perche);
            Debug.Log("送信コマンド: " + command);
        }

        catch (Exception e)
        {
            Debug.LogWarning("UDP送信失敗: " + e.Message);
        }

    }

    void OnApplicationQuit()
  {
        SendBpmCommand("stop");  // ゲーム終了時にBPM記録を停止信号を送る
        SendPercheCommand("stop");
        if(sw == null){
            return;
        }
        sw.Close();

  }
}


