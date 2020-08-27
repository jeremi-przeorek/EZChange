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

            Plugin.Iconize.Iconize.With(new Plugin.Iconize.Fonts.FontAwesomeRegularModule());
            MainPage = new NavigationPage(new IngredientsPage());
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
