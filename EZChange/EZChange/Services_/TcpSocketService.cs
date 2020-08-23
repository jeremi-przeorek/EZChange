using EZChange.Models;
using EZChange.Models.TcpSocket;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;

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

        public static IEnumerable<Ingredient> GetResponse()
        {
            // Buffer to store the response bytes.
            byte[] data2 = new Byte[256];

            // String to store the response ASCII representation.
            String responseData = String.Empty;

            // Read the first batch of the TcpServer response bytes.
            Int32 bytes = _stream.Read(data2, 0, data2.Length);
            responseData = System.Text.Encoding.ASCII.GetString(data2, 0, bytes);

            var ingredient = JsonConvert.DeserializeObject<Ingredient>(responseData);

            return new List<Ingredient> { ingredient };
        }
    }
}
