using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ElectricVehicle
{
    class NetworkManager
    {
        private Socket _socket = null;
        private Socket acceptedSocket = null;
        private IPEndPoint ipEndPoint = null;
        private Thread acceptThread = null;
        private int Port = 0303;

        public void Connect(ActionFlag flag)
        {
            flag.SetFlag(true);
            
            IPAddress ipAddress = IPAddress.Any; // problem garval end Any deer baij magad
            this.ipEndPoint = new IPEndPoint(ipAddress, Port);
            this._socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            acceptThread = new Thread(new ThreadStart(WaitSocket));
            acceptThread.Start();
        }

        public void WaitSocket()
        {
            try
            {
                this._socket.Bind(this.ipEndPoint);
                this._socket.Listen(10); // -1 baij bolno

                while (true)
                {
                    this.acceptedSocket = _socket.Accept();
                    //string acceptedIpaddress = ((IPEndPoint)this.acceptedSocket.RemoteEndPoint).Address.ToString(); // Odoohondoo hereggui (client IP addr)                    
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        public Socket GetSocket()
        {
            return this.acceptedSocket;
        }

        public void Disconnect(ActionFlag flag)
        {            
            flag.SetFlag(false);
            if (this.acceptedSocket != null)
            {
                this.acceptedSocket.Close();
                this.acceptedSocket = null;
            }
        }

        public string GetCommand(Socket _socket)
        {
            Encoding commandDecoder = Encoding.Default;
            string Command = null;
            byte[] Buffer = new byte[1024];
            int BufferCnt = 0;

            try
            {
                Buffer.Initialize();
                BufferCnt = _socket.Receive(Buffer);

                if (BufferCnt > 0)
                {
                    Command = commandDecoder.GetString(Buffer);
                }
            }
            catch (Exception ex)
            {
                Command = null;
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

            return Command;
        }

        public void SendState(Socket _socket, string message)
        {
            byte[] ByteMessage = new Byte[1024];

            ByteMessage = Encoding.ASCII.GetBytes(message);

            _socket.Send(ByteMessage, ByteMessage.Length, 0);
        }
    }
}
