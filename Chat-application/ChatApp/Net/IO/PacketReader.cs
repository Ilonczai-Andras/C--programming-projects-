using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace ChatClient.Net.IO
{
    class PacketReader : BinaryReader
    {
        private NetworkStream _ns;
        public PacketReader(NetworkStream ns) : base(ns)
        {
            _ns = ns;
        }public string ReadMessage()
        {
            int msgLength = ReadInt32();
            byte[] msgBytes = new byte[msgLength];
            _ns.Read(msgBytes, 0, msgLength);

            string msg = Encoding.UTF8.GetString(msgBytes);
            return msg;
        }
        
    }
}
