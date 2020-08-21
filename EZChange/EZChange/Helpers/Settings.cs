// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace EZChange.Helpers
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Tcp Socket Ip Constants

        private const string TcpSocketIpSettingsKey = "tcp_socket_ip";
        private static readonly string TcpSocketIpSettingsDefault = "192.168.1.10";

        #endregion

        public static string TcpSocketIp
        {
            get
            {
                return AppSettings.GetValueOrDefault(
                    TcpSocketIpSettingsKey, TcpSocketIpSettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(
                    TcpSocketIpSettingsKey, value);
            }
        }

        #region Tcp Socket Gateway Constants

        private const string TcpSocketGatewaySettingsKey = "tcp_socket_gateway";
        private static readonly string TcpSocketGatewaySettingsDefault = "255.255.255.0";

        #endregion

        public static string TcpSocketGateway
        {
            get
            {
                return AppSettings.GetValueOrDefault(
                    TcpSocketGatewaySettingsKey, TcpSocketGatewaySettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(
                    TcpSocketGatewaySettingsKey, value);
            }
        }
    }
}