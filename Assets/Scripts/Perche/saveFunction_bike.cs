using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;//CSV�ۑ����邽�߂ɕK�v
using System;//DataTime(�f�[�^�擾�̓������L�^�j���g���̂ɕK�v
using System.Data;
using System.Text;

public class saveFunction_bike : MonoBehaviour
{
  private StreamWriter sw;

  private Transform _carTrans;
  private CarController _car;
  public Movement_Base_Logitec _autoCar;
  public Perche_move _perche;
  public Bike_SetActive _bike;

  float _time;

  string format = "f4";

  int save_number;

  [SerializeField] public Rigidbody car_Rigidbody;
  [SerializeField] public Rigidbody bike_Rigidbody;

  public bool perche;

  public Bike_move bike_move;

  // Start is called before the first frame update
  void Start()
  {
    _carTrans = GameObject.FindGameObjectWithTag("Player").transform;
    _car = _carTrans.GetComponent<CarController>();



    //excel�t�@�C�����̐擪������
    string filename = "sampleFile";

    //�t�@�C�����ɓ��t���L��
    DateTime now = DateTime.Now;

    save_number = PlayerPrefs.GetInt("Save_Number", 0);
    save_number++;
    PlayerPrefs.SetInt("Save_Number", save_number);

    filename = filename + now.Year.ToString() + "_" + now.Month.ToString() + "_" + now.Day.ToString() + "_" + now.Hour.ToString() + "_" + now.Minute.ToString() + "_" + save_number + "_" + bike_move.speed_type.ToString();

    sw = new StreamWriter(filename + ".csv", true, Encoding.GetEncoding("Shift_JIS"));
    string[] s1 = { "Time", "Accel", "Brake", "Car_Speed", "Car_Status", "Bike_Status", "Bike_Distance" };//�\�̈�ԏ�ɓ���鍀�ږ��������Ŏw��
    string s2 = string.Join(",", s1);//������ɋ�؂������
    sw.WriteLine(s2);

  }

  public void SaveData(string txt1, string txt2, string txt3, string txt4, string txt5, string txt6, string txt7)//�f�[�^�擾�̃I�u�W�F�N�g�ɃA�^�b�`����X�N���v�g���ŌĂяo�����֐�
  {

    string[] s1 = { txt1, txt2, txt3, txt4, txt5, txt6, txt7 };
    string s2 = string.Join(",", s1);
    sw.WriteLine(s2);
  }

  void Update()
  {
    _time += Time.deltaTime;


    /*LogitechGSDK.DIJOYSTATE2ENGINES rec = LogitechGSDK.LogiGetStateUnity(0);

    float accel = -1 *(rec.lY / 65536f) + 0.5f;           // アクセルペダル操作量が最大１になるようにしている（踏んでいないときは０）
    float brake = -1 *(rec.lRz / 65536f) + 0.5f;          // ブレーキ*/


    //float accel = 0.5f;           // アクセルペダル操作量が最大１になるようにしている（踏んでいないときは０）
    //float brake = 0f;



    //SaveData(_time.ToString(format),accel.ToString(format),brake.ToString(format),Bike_Distance.DisZ1.ToString(format),Bike_Distance.DisZ2.ToString(format));*/
    //SaveData(_time.ToString(format), accel.ToString(format), brake.ToString(format), _autoCar.moveSpeed.ToString(format), _autoCar.car_status.ToString(), perche.ToString(), Bike_Distance.DisZ1.ToString(format));
    SaveData(_time.ToString(format), _car.AccelInput.ToString(format), _car.BrakeInput.ToString(format), _autoCar.moveSpeed.ToString(format), _autoCar.car_status.ToString(), _bike.bike_status.ToString(), Bike_Dis.DisZ1.ToString(format));

  }

  void OnApplicationQuit()
  {

    sw.Close();


  }
}


