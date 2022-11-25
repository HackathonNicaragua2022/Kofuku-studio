using Descubre_Nica.View;
using Descubre_Nica.ViewModel;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Descubre_Nica
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Transparente();

            if (Application.Current.Properties.ContainsKey("banda"))
            {
                string band = Application.Current.Properties["banda"] as string;
                if (band == "1")
                {
                    MainPage = new NavigationPage(new LoginPage());
                }
            }
            else
            {
                MainPage = new NavigationPage(new Page1());
            }

            
            
        }

        public void Transparente()
        {
            DependencyService.Get<VMStatusBar>().Transparente();
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
