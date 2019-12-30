using GoSONICServer.Entity;
using GoSONICServer.Folder;
using GoSONICServer.Network.Packets;
using GoSONICServer.Network.Sockets;
using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace GoSONICServer
{
    class Program
    {
        public static ServerSocket socket;
        static void Main(string[] args)
        {
            socket = new ServerSocket(11000);
            socket.OnStartingEvent += Socket_OnStartingEvent;
            socket.OnNewConnEvent += Socket_OnNewConnEvent;
            socket.OnReceivingEvent += Socket_OnReceivingEvent;
            socket.Start();
        }
        public static List<Character> charactersPool = new List<Character>();

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
            int packetNumber = BitConverter.ToUInt16(Packet, 2);
            switch (packetNumber)
            {
                case 1000:
                    Connect connectPacket = new Connect(Packet);
                    Character c = new Character(connectPacket.Character, S);
                    c.CharacterID = (byte)charactersPool.Count;
                    connectPacket.CharacterID = c.CharacterID;
                    socket.Send(S, connectPacket.Packet());
                    charactersPool.Add(c);

                    if (charactersPool.Count == 2)
                    {
                        GroundedObject GO = new GroundedObject();
                        GO.CharacterType = 0;
                        for (int i = 0; i < Constants.enemiesCount; i++)
                            GO.Buffer[i + 6] = (byte)(new Random().Next(0, 3));
                        socket.Send(charactersPool[0].socket, GO.Packet());
                        socket.Send(charactersPool[1].socket, GO.Packet());

                        GO.CharacterType = 1;
                        for (int i = 0; i < Constants.ringsCount; i++)
                            GO.Buffer[i + 6] = (byte)(new Random().Next(0, 3)); 
                        socket.Send(charactersPool[0].socket, GO.Packet());
                        socket.Send(charactersPool[1].socket, GO.Packet());
                    }
                    break;
            }
        }
    }
}
