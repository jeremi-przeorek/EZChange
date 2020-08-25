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

        #region Tcp Socket Port Constants

        private const string TcpSocketPortSettingsKey = "tcp_socket_port";
        private static readonly int TcpSocketPortSettingsDefault = 57000;

        #endregion

        public static int TcpSocketPort
        {
            get
            {
                return AppSettings.GetValueOrDefault(
                    TcpSocketPortSettingsKey, TcpSocketPortSettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(
                    TcpSocketPortSettingsKey, value);
            }
        }
    }
}