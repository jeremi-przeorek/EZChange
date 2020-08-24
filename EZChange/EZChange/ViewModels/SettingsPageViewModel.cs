using EZChange.Helpers;
using EZChange.Services_;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace EZChange.ViewModels
{
    public class SettingsPageViewModel : BaseViewModel
    {
        public SettingsPageViewModel()
        {
            Connect = new Command(ConnectTcp);
        }
        public string Title => "Settings";

        private string _tcpStatus;

        public string TcpStatus
        {
            get { return _tcpStatus; }
            set { SetValue(ref _tcpStatus, value); }
        }


        public string IP
        {
            get { return Settings.TcpSocketIp; }
            set { Settings.TcpSocketIp = value; }
        }

        public int Port
        {
            get { return Settings.TcpSocketPort; }
            set { Settings.TcpSocketPort = value; }
        }
        public ICommand Connect { get; private set; }

        public void ConnectTcp()
        {
            string tcpSocketIp = Settings.TcpSocketIp.Replace(',', '.');
            var status = TcpSocketService.Connect(tcpSocketIp, Settings.TcpSocketPort);
            TcpStatus = status;
        }
    }
}

