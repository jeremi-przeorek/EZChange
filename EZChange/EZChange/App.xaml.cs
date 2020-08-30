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

            MainPage = new NavigationPage(new IngredientsPage())
            {
                BarBackgroundColor = Color.FromRgb(119, 208, 235),
                BarTextColor = Color.Black,
            };
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
