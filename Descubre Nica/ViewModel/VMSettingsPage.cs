using Descubre_Nica.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Descubre_Nica.ViewModel
{
    internal class VMSettingsPage: BaseViewModel 
    {

        #region Variables
        public string _Texto;
        #endregion
        #region Constructores
        public VMSettingsPage(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion
        #region Objetos
        public string Texto
        {
            get { return _Texto; }
            set { SetValue(ref _Texto, value); }
        }
        #endregion
        #region Procesos
        public async Task Logout()
        {
            string band = "0";

            Application.Current.Properties["LoginBanda"] = band;
            await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
        }
        public void ProcesoSimple()
        {

        }
        #endregion
        #region Comandos
        public ICommand LogoutCommand => new Command(async () => await Logout());
        public ICommand ProcesoSimpCommand => new Command(ProcesoSimple);
        #endregion

    }
}
