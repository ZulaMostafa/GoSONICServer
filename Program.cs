using GoSONICServer.Network.Sockets;
using System;

namespace GoSONICServer
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerSocket socket = new ServerSocket(11000);
            socket.OnStartingEvent += Socket_OnStartingEvent;
            socket.OnNewConnEvent += Socket_OnNewConnEvent;
            socket.OnReceivingEvent += Socket_OnReceivingEvent;
            socket.Start();
        }

        private static void Socket_OnStartingEvent()
        {
            Console.WriteLine("---Server is Starting----");
        }

        private static void Socket_OnNewConnEvent(System.Net.Sockets.Socket S)
        {
            Console.WriteLine("A new player has joined");
        }

        private static void Socket_OnReceivingEvent(System.Net.Sockets.Socket S, byte[] Packet)
        {
            Console.WriteLine("Packet Receive");
        }
    }
}
