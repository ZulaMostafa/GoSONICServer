using GoSONICServer.Kernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoSONICServer.Network.Packets
{
    public class Movement : PacketWriter
    {
        public byte[] Buffer;
        const int PacketSize = 7;
        public Movement()
        {
            Buffer = new byte[PacketSize];
            WriteUshort(PacketSize, 0, Buffer);
            WriteUshort(1006, 0, Buffer);
        }
        public Movement(byte[] b)
        {
            Buffer = b;
        }

        public byte Type
        {
            get { return Buffer[5]; }
            set { Buffer[5] = value; }
        }


        public byte ID
        {
            get { return Buffer[6]; }
            set { Buffer[6] = value; }
        }

    }
}
