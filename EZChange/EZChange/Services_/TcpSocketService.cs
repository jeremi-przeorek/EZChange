using EZChange.Models.TcpSocket;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace EZChange.Services_
{
    public static class TcpSocketService
    {
        private static TcpClient _tcpClient;
        private static NetworkStream _stream;

        public static bool Connect(string ip, int port)
        {
            try
            {
                _tcpClient = new TcpClient(ip, port);
                _stream = _tcpClient.GetStream();

                return _tcpClient.Connected;
            }
            catch (SocketException ea)
            {
                return false;
            }
        }

        public static void Send(TcpSocketRequest request)
        {
            var serializedRequest = JsonConvert.SerializeObject(request);
            byte[] data = System.Text.Encoding.ASCII.GetBytes(serializedRequest);
            _stream.Write(data, 0, data.Length);
        }
    }
}
