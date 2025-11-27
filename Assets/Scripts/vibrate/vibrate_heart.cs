using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System;

public class vibrate_heart : MonoBehaviour
{
    public int listenPort = 5010;  // 受信ポート（Pythonと合わせる）
    private UdpClient udpClient;

    void Start()
    {
        udpClient = new UdpClient(listenPort);
        udpClient.BeginReceive(ReceiveCallback, null);
        Debug.Log("UDP受信開始 (ポート: " + listenPort + ")");
    }

    void ReceiveCallback(IAsyncResult ar)
    {
        try
        {
            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, listenPort);
            byte[] data = udpClient.EndReceive(ar, ref remoteEP);

            if (data.Length >= 4)
            {
                int receivedValue = BitConverter.ToInt32(data, 0); // 32bit整数として解釈
                Debug.Log("受信した値: " + receivedValue);
            }
            else
            {
                Debug.LogWarning("受信データが短すぎます: " + data.Length);
            }
        }
        catch (Exception e)
        {
            Debug.LogError("UDP受信エラー: " + e.Message);
        }
        finally
        {
            udpClient.BeginReceive(ReceiveCallback, null); // 継続して受信
        }
    }

    void OnApplicationQuit()
    {
        udpClient?.Close();
    }
}
