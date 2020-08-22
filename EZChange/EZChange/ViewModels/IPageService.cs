using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EZChange.ViewModels
{
    public interface IPageService
    {
        Task PushAsync(Page page);
        Task<string> DisplayActionSheet(
            string title, string cancel, string destruction, params string[] buttons);
        Task DisplayAlert(string title, string message, string cancel);
    }
}
