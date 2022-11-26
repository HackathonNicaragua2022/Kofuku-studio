using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Descubre_Nica.View;
using Descubre_Nica.Model;
using Firebase.Auth;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace Descubre_Nica.ViewModel
{
    public class VMLogin : BaseViewModel
    {

        #region Variables
        public string _correo;
        public string _contraseña;

        #endregion
        #region Constructores
        public VMLogin(INavigation navigation)
        {
            Transparente();
            Navigation = navigation;
        }
        #endregion
        #region Objetos
        public string Correo
        {
            get { return this._correo; }
            set { SetValue(ref this._correo, value); }
        }
        public string Contraseña
        {
            get { return this._contraseña; }
            set { SetValue(ref this._contraseña, value); }
        }
        #endregion
        #region Procesos
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }
        public async void Login()
        {
            if (string.IsNullOrEmpty(this._correo))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error", "Debes ingresar tu correo electronico", "Aceptar"
                );
                return;
            }
            if (string.IsNullOrEmpty(this._contraseña))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error", "No has ingresado una contraseña todavia", "Aceptar"
                );
                return;
            }

            string WebAPIKey = "AIzaSyDShqu1iNFJhSy1Jvoqn7vWpwEaUsRFtMM";

            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIKey));
            try
            {
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(Correo.ToString(), Contraseña.ToString());
                var content = await auth.GetFreshAuthAsync();
                var serializedcontnet = JsonConvert.SerializeObject(content);

                Preferences.Set("MyFirebaseRefreshToken", serializedcontnet);
                await Application.Current.MainPage.Navigation.PushAsync(new MainPage());
                string band = "1";

                Application.Current.Properties["LoginBanda"] = band;
                Application.Current.Properties["LoginCorreo"] = _correo;
            }
            catch (Exception)
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Correo y contraseña no validos", "OK");
            }
        }

        public void Transparente()
        {
            DependencyService.Get<VMStatusBar>().Transparente();
        }


        public async Task NavRegisPage()
        {
            await Navigation.PushAsync(new RegisterPage());
        }

        #endregion
        #region Comandos
        public ICommand NavRegisPagecommand => new Command(async () => await NavRegisPage());
        #endregion

    }
}
