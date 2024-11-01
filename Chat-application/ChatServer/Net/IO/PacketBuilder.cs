using System;
using System.IO;
using System.Text;


namespace ChatServer.Net.IO
{
    class PacketBuilder
    {
        MemoryStream _ms;
        public PacketBuilder()
        {
            _ms = new MemoryStream();
        }
        public void WriteOpCode(byte opcode)
        {
            _ms.WriteByte(opcode);
        }
        public void WriteMessage(string msg)
        {
            byte[] msgBytes = Encoding.UTF8.GetBytes(msg);
            int msgLength = msgBytes.Length;

            _ms.Write(BitConverter.GetBytes(msgLength), 0, sizeof(int));
            _ms.Write(msgBytes, 0, msgLength);
        }
        public byte[] GetPacketBytes()
        {
            return _ms.ToArray();
        }
    }
}
