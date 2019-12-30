using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace GoSONICServer.Network.Sockets
{
    public class stateObject
    {
        public Socket workSocket;
        public const int bufferSize = 1024;
        public byte[] buffer = new byte[bufferSize];
    }
    public class ServerSocket
    {
        public ManualResetEvent currentConnection;
        public delegate void OnStarting();
        public event OnStarting OnStartingEvent;

        public delegate void OnReceive(Socket S, byte[] Packet);
        public event OnReceive OnReceivingEvent;

        public delegate void OnNewConn(Socket S);
        public event OnNewConn OnNewConnEvent;

        Socket listener;

        IPEndPoint localEndPoint;

        public ServerSocket(int port)
        {
            currentConnection = new ManualResetEvent(false);
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = IPAddress.Any;
            localEndPoint = new IPEndPoint(IPAddress.Any, 11000);
            listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

        }
        public void Start()
        {
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(100);
                if (OnStartingEvent != null)
                    OnStartingEvent();
                while (true)
                {
                    currentConnection.Reset();

                    Console.WriteLine("Waiting for a connection");
                    listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);
                    currentConnection.WaitOne();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void AcceptCallback(IAsyncResult ar)
        {
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);

            stateObject state = new stateObject();
            state.workSocket = handler;

            if (OnNewConnEvent != null)
                OnNewConnEvent(handler);

            handler.BeginReceive(state.buffer, 0, stateObject.bufferSize, 0, new AsyncCallback(ReadCallback), state);

            currentConnection.Set();
        }
        public void ReadCallback(IAsyncResult ar)
        {
            stateObject state = (stateObject)ar.AsyncState;
            Socket handler = state.workSocket;
            int bytesRead = handler.EndReceive(ar);
            if (bytesRead > 0)
            {
                if (OnReceivingEvent != null)
                {
                    OnReceivingEvent(handler, state.buffer);
                }
            }
            handler.BeginReceive(state.buffer, 0, stateObject.bufferSize, 0, new AsyncCallback(ReadCallback), state);
        }
        public void Send(Socket handler, byte[] data)
        {
            handler.BeginSend(data, 0, data.Length, 0, new AsyncCallback(SendCallback), handler);
        }

        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                Socket handler = (Socket)ar.AsyncState;
                int bytesSent = handler.EndSend(ar);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

    }
}
