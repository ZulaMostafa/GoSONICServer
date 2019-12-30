using GoSONICServer.Kernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoSONICServer.Network.Packets
{
    public class Respawn : PacketWriter
    {
        public byte[] Buffer;
        const int PacketSize = 9;
        public Respawn()
        {
            Buffer = new byte[PacketSize];
            WriteUshort(PacketSize, 0, Buffer);
            WriteUshort(1008, 2, Buffer);
        }

        public Respawn(byte[] b)
        {
            Buffer = b;
        }

        public byte ID
        {
            get { return Buffer[5]; }
            set { Buffer[5] = value; }
        }

        public byte lane
        {
            get { return Buffer[6]; }
            set { Buffer[6] = value; }
        }

        public byte Type
        {
            get { return Buffer[7]; }
            set { Buffer[7] = value; }
        }

        public byte Change
        {
            get { return Buffer[8]; }
            set { Buffer[8] = value; }
        }
    }
}
