using Descubre_Nica.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Descubre_Nica
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new LoginPage());
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
