using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Net;
using System.Threading;

public class SocketUDPClient
{
    UdpClient _udpClient;
    Thread ReceiveThread;
    IPEndPoint TargetIPEndPoint;
    IPEndPoint MyIPEndPoint;
    bool isMsgSend = false;
    bool isMsgReceive = false;
    public delegate void delReceiveData(byte[] bytes);
    public delReceiveData _OnReceiveData;
    bool _bConnect = false;

    string _strTargetUP = "";
    string _strUP = "";
    int _nPort = 0;
    bool _bRead = false;


    public bool Connected
    {
        get { return _bConnect; }
    }

    public bool Connect(string strTagerHost, string strHost, int nPort)
    {
        try
        {
            if (_udpClient == null)
                _udpClient = new UdpClient();

            _strTargetUP = strTagerHost;
            _strUP = strHost;
            _nPort = nPort;

            TargetIPEndPoint = new IPEndPoint(IPAddress.Parse(_strTargetUP), _nPort);
            _udpClient.Connect(TargetIPEndPoint);
            _bConnect = _udpClient.Client.Connected;

            if (_strUP != "")
            {
                MyIPEndPoint = new IPEndPoint(IPAddress.Parse(_strUP), _nPort);
                _udpClient = new UdpClient(MyIPEndPoint); // udpClient에 자기자신 IP , Port 설정

                if (!_bRead)
                {
                    _bRead = true;
                    ReceiveThread = new Thread(ReceiveData); // 연속적으로 데이터를 받기 위해 쓰레드 생성 
                    ReceiveThread.Start();
                }
            }
        }
        catch(Exception ex) { }

        return _bConnect;
    }

    private void ReceiveData()
    {
        while (_bRead)
        {
            if (_udpClient.Available > 0) // 버퍼에 받은 데이터가 있는지 확인
            {
                try
                {
                    _udpClient.BeginReceive(new AsyncCallback(receiveText), _udpClient);// data 비동기 receive data
                    while (!isMsgReceive)
                    {
                        Thread.Sleep(10);
                    }
                    isMsgReceive = false;
                }
                catch (Exception e)
                {
                    // Add log
                }
            }
            else
            {
                Thread.Sleep(10);
            }
        }
    }

    private void Senddata(IAsyncResult result)
    {
        isMsgSend = true;
    }
    private void receiveText(IAsyncResult result)
    {
        if (result.IsCompleted)
        {
            var byteData = ((UdpClient)result.AsyncState).EndReceive(result, ref TargetIPEndPoint); // 버퍼에 있는 데이터 취득
            //var stringData = Encoding.Default.GetString(byteData); // byte[]에서 string으로 변환
            isMsgReceive = true;
            if (_OnReceiveData != null)
                _OnReceiveData(byteData);
        }
    }

    public void StopUDPClient() // 쓰레드와 UDPClient 종료
    {
        _bRead = false;

        Thread.Sleep(100);
        _udpClient?.Close();
    }

    public void SendBytes(byte[] bytes)
    {
        try
        {
            _udpClient.BeginSend(bytes, bytes.Length, new AsyncCallback(Senddata), _udpClient); // 비동기 Send data 
            while (!isMsgSend)
            {
                Thread.Sleep(10);
            }
            isMsgSend = false;
        }
        catch { }
    }
}
