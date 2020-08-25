using EZChange.Models.TcpSocket;
using Newtonsoft.Json;
using System;
using System.Net.Sockets;

namespace EZChange.Services_
{
    public static class TcpSocketService
    {
        private static TcpClient _tcpClient;
        private static NetworkStream _stream;

        public static bool Connect(string ip, int port)
        {
            _tcpClient = new TcpClient(ip, port);
            _stream = _tcpClient.GetStream();

            return _tcpClient.Connected;
        }

        public static void Send(TcpSocketRequest request)
        {
            var serializedRequest = JsonConvert.SerializeObject(request);
            byte[] data = System.Text.Encoding.ASCII.GetBytes(serializedRequest);
            _stream.Write(data, 0, data.Length);
        }

        public static T GetResponse<T>()
        {
            // Buffer to store the response bytes.
            byte[] data = new Byte[2048];

            // String to store the response ASCII representation.
            String responseData = String.Empty;

            // Read the first batch of the TcpServer response bytes.
            Int32 bytes = _stream.Read(data, 0, data.Length);
            responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);

            var response = JsonConvert.DeserializeObject<T>(responseData);

            return response;
        }
    }
}
