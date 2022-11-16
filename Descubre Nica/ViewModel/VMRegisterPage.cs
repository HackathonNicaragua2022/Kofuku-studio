using System;
using System.Collections.Generic;
using System.Text;
using Descubre_Nica.Model;
using System.Threading.Tasks;
using System.Windows.Input;
using Descubre_Nica.View;
using Xamarin.Forms;

namespace Descubre_Nica.ViewModel
{
    public class VMRegisterPage: BaseViewModel
    {
        #region Variables
        public string _Correo;
        public string _Contraseña;

        #endregion
        #region Constructores
        public VMRegisterPage(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion
        #region Objetos
        public string Correo
        {
            get { return _Correo; }
            set { SetValue(ref _Correo, value); }
        }
        public string Contraseña
        {
            get { return _Contraseña; }
            set { SetValue(ref _Contraseña, value); }
        }
        #endregion
        #region Procesos
        public async Task Navegarpag()
        {
            if (Validar())
            {
                await Navigation.PushAsync(new LoginPage());
            }
            else
            {
                await DisplayAlert("Alerta", "Llene todo los campos", "OK");
            }
        }

        public bool Validar()
        {
            if (string.IsNullOrEmpty(Contraseña) || string.IsNullOrEmpty(Correo))
            {
                return false;
            }
            return true;
        }

        #endregion
        #region Comandos
        public ICommand NavegarPagcommand => new Command(async () => await Navegarpag());
        #endregion
    }
}
