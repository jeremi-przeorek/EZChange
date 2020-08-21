using EZChange.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace EZChange.ViewModels
{
    public class SettingsPageViewModel : BaseViewModel
    {
        public string Title = "Settings";

        public string IP
        {
            get { return Settings.TcpSocketIp; }
            set { Settings.TcpSocketIp = value; }
        }

        public string Gateway
        {
            get { return Settings.TcpSocketGateway; }
            set { Settings.TcpSocketGateway = value; }
        }
    }
}
