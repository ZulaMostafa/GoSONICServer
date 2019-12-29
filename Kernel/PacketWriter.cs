using System;
using System.Collections.Generic;
using System.Text;

namespace GoSONICServer.Kernel
{
    public static class PacketWriter
    {
        public static void WriteUshort(ushort arg, int offset, byte[] buffer)
        {
            byte[] Val = BitConverter.GetBytes(arg);
            Buffer.BlockCopy(Val, 0, buffer, offset, Val.Length);
        }

        public static void WriteInt(int arg, int offset, byte[] buffer)
        {
            byte[] Val = BitConverter.GetBytes(arg);
            Buffer.BlockCopy(Val, 0, buffer, offset, Val.Length);
        }

        public static void WriteLong(long arg, int offset, byte[] buffer)
        {
            byte[] Val = BitConverter.GetBytes(arg);
            Buffer.BlockCopy(Val, 0, buffer, offset, Val.Length);
        }
        public static void WriteBoolean(bool arg, int offset, byte[] buffer)
        {
            byte[] Val = BitConverter.GetBytes(arg);
            Buffer.BlockCopy(Val, 0, buffer, offset, Val.Length);
        }
        public static void WriteByte(byte arg, int offset, byte[] buffer)
        {
            byte[] Val = BitConverter.GetBytes(arg);
            Buffer.BlockCopy(Val, 0, buffer, offset, Val.Length);
        }
        public static void WriteString(string arg, int offset, byte[] buffer)
        {
            byte[] Val = Encoding.Default.GetBytes(arg);
            Buffer.BlockCopy(Val, 0, buffer, offset, Val.Length);
        }
    }
}
