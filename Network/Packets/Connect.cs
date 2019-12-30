using GoSONICServer.Kernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoSONICServer.Network.Packets
{
    public class Connect : PacketWriter
    {
        byte[] Buffer;
        const int packetSize = 7;
        public Connect()
        {
            Buffer = new byte[packetSize];
            WriteUshort(packetSize, 0, Buffer); //Packet Size
            WriteUshort(1000, 2, Buffer); //Packet Number
        }
        public Connect(byte[] b)
        {
            Buffer = b;
        }

        public byte Character
        {
            get { return Buffer[5]; }
            set { Buffer[5] = value; }
        }

        public byte CharacterID
        {
            get { return Buffer[6];  }
            set { Buffer[6] = value; }
        }

        public byte[] Packet()
        {
            return Buffer;
        }
    }
}
