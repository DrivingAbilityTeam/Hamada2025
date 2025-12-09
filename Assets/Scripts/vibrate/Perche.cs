using UnityEngine;
using System.Net.Sockets;
using System.Text;
using System;
using System.Threading;
using System.Net;

public class Perche : MonoBehaviour
{
    private string host = "192.168.11.55";//���Y�p�C�̐ݒ肩��m�F�ł���z�X�g��
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
    private int receivePort = 5020;
    private bool isRunning = true;//��M�X���b�h�̎��s���
    public float temperature;

    void Start()
    {
        client = new UdpClient();
        client.Connect(host, port);
    }

    private void SendPerche() 
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

    /// ボックスに触れたときに呼ばれる
    /// </summary>
    void OnTriggerEnter(Collider other)
    {
        if (!this.enabled) { return; } //スクリプトを非アクティブにしてもトリガーは有効なため、この一行を入れる

        if (other.CompareTag("Perche_On"))
        {
            SendPerche();
            other.gameObject.SetActive(false);
        }

    }

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
