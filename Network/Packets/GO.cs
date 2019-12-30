using GoSONICServer.Kernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoSONICServer.Network.Packets
{
    public class GO : PacketWriter
    {
        public byte[] Buffer;
        const int PacketSize = 6;
        public GO()
        {
            Buffer = new byte[PacketSize];
            WriteUshort(PacketSize, 0, Buffer);
            WriteUshort(1004, 2, Buffer);
        }

        public GO(byte[] B)
        {
            Buffer = B;
        }

        public byte SecondCharacter
        {
            get { return Buffer[5]; }
            set { Buffer[5] = value; }
        }
    }
}
