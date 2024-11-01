using ChatClient.Net.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.Net
{
    class Server
    {
        TcpClient _client;
        public PacketReader PacketReader;
        public event Action connectedEvent;
        public event Action msgReceivedEvent;
        public event Action userDisconnectedEvent;
        public Server() {

            _client = new TcpClient();
        }
        public void ConnectToServer(string username) //string password
        {
            if (!_client.Connected)
            {
                _client.Connect("127.0.0.1", 7891);
                PacketReader = new PacketReader(_client.GetStream());

                if (!string.IsNullOrEmpty(username)) //&& !string.IsNullOrEmpty(password)
                {
                    var connectPacket = new PacketBuilder();
                    connectPacket.WriteOpCode(0);
                    connectPacket.WriteMessage(username);
                    //connectPacket.WriteMessage(password);
                    _client.Client.Send(connectPacket.GetPacketBytes());
                }
                ReadPackets();
            }
        }

        public void DisconnectFromServer()
        {
            if (_client.Connected)
            {
                _client.Close();
            }
        }



        private void ReadPackets()
        {
            Task.Run(() =>
            {
                try
                {
                    while (true)
                    {
                        if (PacketReader.BaseStream.CanRead)
                        {
                            var opcode = PacketReader.ReadByte();
                            switch (opcode)
                            {
                                case 1:
                                    connectedEvent?.Invoke();
                                    break;
                                case 5:
                                    msgReceivedEvent?.Invoke();
                                    break;
                                case 10:
                                    userDisconnectedEvent?.Invoke();
                                    break;
                                default:
                                    Console.WriteLine($"Unknown opcode received: {opcode}");
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Network stream not readable");
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading from network stream: {ex.Message}");
                }
            });
        }

        public void SendMessageToServer(string message)
        {
            var messagePacket = new PacketBuilder();
            messagePacket.WriteOpCode(5);
            messagePacket.WriteMessage(message);
            _client.Client.Send(messagePacket.GetPacketBytes());
        }
    }
}
