using PathCreation;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Base_Logitec : MonoBehaviour
{
    [SerializeField] PathCreator pathCreator;
    public float moveSpeed;//�C���X�y�N�^��Ɍ����邪�A�X�N���v�g�Őݒ肳��Ă���̂ŏ������܂Ȃ��B�o�͊m�F�p�B
    [SerializeField] private float SlowSpeed;
    [SerializeField] GameObject car;

    //���x�ύX�������ꍇ
    [SerializeField] private bool ChangeMode;//自動減速・加速を有効にするか
    [SerializeField] private float ChangeSpeed1;
    [SerializeField] private float ChangeSpeed2;


    private bool human = false;
    private bool stop = false;
    public bool car_status = false;//true�Ȃ瓮���Ă���B�o�͊m�F�p�B
    private Rigidbody rb;

    Vector3 endPos;

    float moveDistance;
    private Transform _carTrans;
    private CarController _car;//�A�N�Z���ƃu���[�L�ʂ��Q�Ƃ��邽�߂ɕK�v

    //LogitechGSDK.DIJOYSTATE2ENGINES rec = LogitechGSDK.LogiGetStateUnity(0);
    public enum SpeedType
    {
        Keyboard, Handle
    }
    [Header("�L�[�{�[�hor�R���g���[���[�H�H")]
    public SpeedType speed_type;


    void Start()
    {
        moveSpeed = SlowSpeed;
        endPos = pathCreator.path.GetPoint(pathCreator.path.NumPoints - 1);//�A�Z�b�g�񋟂̃��\�b�h���g�p�F�ŏI�n�_�̍��W���擾�i�o�H��̓_�̐� �[�P�j
        rb = car.GetComponent<Rigidbody>();  // rigidbody���擾
        _carTrans = GameObject.FindGameObjectWithTag("Player").transform;
        _car = _carTrans.GetComponent<CarController>();//�A�N�Z���ƃu���[�L�ʂ��Q�Ƃ��邽�߂ɕK�v

    }


    void Update()
    {
        //float accel = -1 * (rec.lY / 65536f) + 0.5f; // �A�N�Z���y�_�������(0�`1)
        //float brake = -1 * (rec.lRz / 65536f) + 0.5f;//�u���[�L�y�_�������(0�`1)

        float accel = _car.AccelInput;
        float brake = _car.BrakeInput;

        if (!stop)
        {
            
            moveDistance += moveSpeed / 3.6f * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(moveDistance, EndOfPathInstruction.Stop);
            transform.rotation = pathCreator.path.GetRotationAtDistance(moveDistance, EndOfPathInstruction.Stop);//�A�Z�b�g�񋟂̃��\�b�h�F�o�H��̂ǂ��ɂ��Ă��i�s�����������悤�ɐݒ�

        }
        if (speed_type == SpeedType.Keyboard)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {

                stop = true;
                car_status = false;


            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                stop = false;
                car_status = true;

            }
        }

        if (speed_type == SpeedType.Handle)
        {
            if (brake > accel)//ブレーキを踏んでいる場合
            {

                stop = true;
                car_status = false;

            }
            else//アクセルが入っている場合
            {
                stop = false;
                car_status = true;

            }
            
        }

        if (ChangeMode && !stop)
        {

            if (ChangeSpeedAuto.slowmode)//減速
            {

                float SpeedGap = ChangeSpeed1 - moveSpeed;
                moveSpeed += SpeedGap * 1.1f * Time.deltaTime; // 補間スピードは調整可

            }
            else if (ChangeSpeedAuto.restart)//加速
            {

                 moveSpeed += 10f * Time.deltaTime;

                 if (moveSpeed > SlowSpeed)
                 {
                     moveSpeed = SlowSpeed;
                 }

            }

        }

    }


}