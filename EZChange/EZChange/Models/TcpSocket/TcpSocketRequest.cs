namespace EZChange.Models.TcpSocket
{
    public enum TcpRequestType
    {
        ResetAmount, GetIngredientAmount
    }

    public class TcpSocketRequest
    {
        public TcpRequestType TcpRequestType { get; set; }
        public string Target { get; set; }
        public int Value { get; set; }
    }
}
