using System;
using System.Collections.Generic;
using System.Text;

namespace EZChange.Models.TcpSocket
{
    enum TcpRequestType
    {
        ResetAmount, GetIngredientAmount
    }

    class TcpSocketRequest
    {
        public TcpRequestType TcpRequestType { get; set; }
        public string Target { get; set; }
        public int Value { get; set; }
    }
}
