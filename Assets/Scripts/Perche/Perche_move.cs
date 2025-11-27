using UnityEngine;
using System.Net.Sockets;
using System.Text;
using System;
using System.Threading;
using System.Net;

public class Perche_move : MonoBehaviour
{
    private string host = "driving-hamada.local";//���Y�p�C�̐ݒ肩��m�F�ł���z�X�g��
    //���Y�p�C�ւ̑��M�|�[�g
    private int port = 60000;//���Y�p�C�̐��E��_UDP�p�v���O�����̃|�[�g�ԍ�
    private UdpClient client;
    public int Target_Temperature;
    public int Target_Time;
    private int Peltier_OFF = 0;
    private int Peltier_ON = 1;

    //���Y�p�C����̎�M�p�|�[�g
    private UdpClient receiveClient;
    private Thread receiveThread;
    private int receivePort = 5005;
    private bool isRunning = true;//��M�X���b�h�̎��s���
    public float temperature;

    void Start()
    {
        client = new UdpClient();
        client.Connect(host, port);

        /*receiveClient = new UdpClient(receivePort);
        receiveThread = new Thread(new ThreadStart(ReceiveData));
        receiveThread.IsBackground = true;
        receiveThread.Start();*/
    }


    void Update()
    {
        if (Hit_Bike.perche_Active)//���߂Ƀo�C�N���o�������^�C�~���O���L�^
        {
            Debug.Log("Send");
            Debug.Log("送信するTarget_Time: " + Target_Time);
            byte[] message = new byte[12];//4�o�C�g(Peltier_ON)+4�o�C�g(Target_Temperature)
            Buffer.BlockCopy(BitConverter.GetBytes(Peltier_ON), 0, message, 0, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(Target_Temperature), 0, message, 4, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(Target_Time), 0, message, 8, 4);
            client.Send(message, message.Length);
            Hit_Bike.perche_Active = false;

        }


        /*if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Send");
            byte[] message = new byte[12];//4�o�C�g(Peltier_ON)+4�o�C�g(Target_Temperature)
            Buffer.BlockCopy(BitConverter.GetBytes(Peltier_ON), 0, message, 0, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(Target_Temperature), 0, message, 4, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(Target_Time), 0, message, 8, 4);
            //var message = BitConverter.GetBytes(Peltier_ON);
            //var message = Encoding.UTF8.GetBytes("Hello World!");
            client.Send(message, message.Length);
        }

        else if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Send");
            byte[] message = new byte[12];//4�o�C�g(Peltier_OFF)+4�o�C�g(Target_Temperature)
            Buffer.BlockCopy(BitConverter.GetBytes(Peltier_OFF), 0, message, 0, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(Target_Temperature), 0, message, 4, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(Target_Time), 0, message, 8, 4);
            //var message = BitConverter.GetBytes(Peltier_OFF);
            client.Send(message, message.Length);
        }*/
    }
    /*private void ReceiveData()
    {
        IPEndPoint anyIP = new IPEndPoint(IPAddress.Parse("192.168.11.64"), receivePort);

        while (isRunning) // isRunning��true�̊ԁA��M�𑱂���
        {
            if (receiveClient.Available > 0)
            {
                byte[] data = receiveClient.Receive(ref anyIP);
                string message = Encoding.UTF8.GetString(data);
                float.TryParse(message, out temperature);
                Debug.Log("Temperature: " + temperature.ToString("F2") + " ℃");
            }
            else
            {
                Debug.Log("データが取得できませんでした");
            }
        }
    }*/

    private void OnDestroy()
    {
        isRunning = false;//�X���b�h���[�v���I��
        if(client == null){
            return;
        }
       
        client.Close();

        if(receiveClient == null){
            return;
        }
        receiveClient.Close();
    }
}
