using GoSONICServer.Kernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoSONICServer.Network.Packets
{
    public class GroundedObject : PacketWriter
    {
        public byte[] Buffer;
        public const int PacketSize = 50;
        public GroundedObject(byte[] b)
        {
            Buffer = b;
        }
        public GroundedObject()
        {
            Buffer = new byte[PacketSize];
            WriteUshort(PacketSize, 0, Buffer);
            WriteUshort(1002, 2, Buffer);
        }

        public byte CharacterType
        {
            get { return Buffer[5]; }
            set { Buffer[5] = value; }
        }
        public byte[] Packet()
        {
            return Buffer;
        }
    }
}
