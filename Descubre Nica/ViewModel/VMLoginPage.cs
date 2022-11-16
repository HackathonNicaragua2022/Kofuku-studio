using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Descubre_Nica.View;
using Descubre_Nica.Model;

namespace Descubre_Nica.ViewModel
{
    public class VMLogin : BaseViewModel
    {

        #region Variables
        public string _Usuario;
        public string _contraseña;
        public List<MLogin> listUsers { get; set; }

        #endregion
        #region Constructores
        public VMLogin(INavigation navigation)
        {
            Transparente();
            Navigation = navigation;
        }
        #endregion
        #region Objetos
        public string Usuario
        {
            get { return _Usuario; }
            set { SetValue(ref _Usuario, value); }
        }
        public string Contraseña
        {
            get { return _contraseña; }
            set { SetValue(ref _contraseña, value); }
        }
        #endregion
        #region Procesos
        public async Task Navegarpag()
        {
            if (Validar())
            {
                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                await DisplayAlert("Alerta", "Llene todo los campos", "OK");
            }
        }
        public void Transparente()
        {
            DependencyService.Get<VMStatusBar>().Transparente();
        }

        public bool Validar()
        {
            if (string.IsNullOrEmpty(Contraseña) || string.IsNullOrEmpty(Usuario))
            {
                return false;
            }
            return true;
        }

        public async Task NavRegisPage()
        {
            await Navigation.PushAsync(new RegisterPage());
        }

        #endregion
        #region Comandos
        public ICommand NavegarPagcommand => new Command(async () => await Navegarpag());
        public ICommand NavRegisPagecommand => new Command(async () => await NavRegisPage());
        #endregion

    }
}
