using Descubre_Nica.View;
using Descubre_Nica.ViewModel;
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
            Transparente();
            MainPage = new NavigationPage(new Page1());
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
