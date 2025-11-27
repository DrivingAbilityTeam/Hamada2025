using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;//CSV�ۑ����邽�߂ɕK�v
using System;//DataTime(�f�[�^�擾�̓������L�^�j���g���̂ɕK�v
using System.Data;
using System.Text;

public class saveFunction2 : MonoBehaviour
{
  private StreamWriter sw;

  private Transform _carTrans;
  private CarController _car;

  float _time;

  string format = "f4";

  int save_number;

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

    filename = filename + now.Year.ToString() + "_" + now.Month.ToString() + "_" + now.Day.ToString() + "_" + now.Hour.ToString() + "_" + now.Minute.ToString() + "_" + save_number;

    sw = new StreamWriter(filename + ".csv", true, Encoding.GetEncoding("Shift_JIS"));
    string[] s1 = { "Time", "Accel", "Brake", "Human_B", "Human_F", "Bike" };//�\�̈�ԏ�ɓ���鍀�ږ��������Ŏw��
    string s2 = string.Join(",", s1);//������ɋ�؂������
    sw.WriteLine(s2);

  }

  public void SaveData(string txt1, string txt2, string txt3, string txt4, string txt5, string txt6)//�f�[�^�擾�̃I�u�W�F�N�g�ɃA�^�b�`����X�N���v�g���ŌĂяo�����֐�
  {

    string[] s1 = { txt1, txt2, txt3, txt4, txt5, txt6 };
    string s2 = string.Join(",", s1);
    sw.WriteLine(s2);
  }

  void Update()
  {
    _time += Time.deltaTime;

    /*LogitechGSDK.DIJOYSTATE2ENGINES rec = LogitechGSDK.LogiGetStateUnity(0);

    float accel = -1 *(rec.lY / 65536f) + 0.5f;           // アクセル
    float brake = -1 *(rec.lRz / 65536f) + 0.5f;          // ブレーキ



      SaveData(_time.ToString(format),accel.ToString(format),brake.ToString(format),Bike_Distance.DisZ1.ToString(format),Bike_Distance.DisZ2.ToString(format));*/
    SaveData(_time.ToString(format), _car.AccelInput.ToString(format), _car.BrakeInput.ToString(format), Human_Distance.DisZ1.ToString(format), HF_Distance.DisZ1.ToString(format), Bike_Distance.DisZ1.ToString(format));

    if (Input.GetKeyDown(KeyCode.Return))
    {
      sw.Close();

    }
  }

  void OnApplicationQuit()
  {

    sw.Close();


  }
}


