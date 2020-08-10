using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EZChange.Views;

namespace EZChange
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new IngredientsPage();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
