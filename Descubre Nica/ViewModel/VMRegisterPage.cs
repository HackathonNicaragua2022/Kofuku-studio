using System;
using System.Collections.Generic;
using System.Text;
using Descubre_Nica.Model;
using System.Threading.Tasks;
using System.Windows.Input;
using Descubre_Nica.View;
using Xamarin.Forms;
using Firebase.Auth;
using CommunityToolkit.Mvvm.Input;
using Descubre_Nica.Services;
using System.Drawing;

namespace Descubre_Nica.ViewModel
{
    public class VMRegisterPage: BaseViewModel
    {
        FirebaseUsuarios firebaseusers = new FirebaseUsuarios();

        #region Variables
        public string _Correo;
        public string _NUser;
        public string _Sexo;
        public int _edad;
        public string _Contraseña;


        public bool isRefreshing = false;


        public object listViewSource;

        public bool _isRunning;
        public bool _isVisible;
        public bool _isEnabled;

        #endregion
        #region Constructores
        public VMRegisterPage(INavigation navigation)
        {
            Navigation = navigation;
        }
        public VMRegisterPage()
        {
            _=LoadData();
        }
        #endregion
        #region Objetos

        public string Correo
        {
            get { return this._Correo; }
            set { SetValue(ref this._Correo, value); }
        }
        public string NUser
        {
            get { return this._NUser; }
            set { SetValue(ref this._NUser, value); }
        }
        public string Contraseña
        {
            get { return this._Contraseña; }
            set { SetValue(ref this._Contraseña, value); }
        }
        public string Sexo
        {
            get { return this._Sexo; }
            set { SetValue(ref this._Sexo, value); }
        }
        public int Edad
        {
            get { return this._edad; }
            set { SetValue(ref this._edad, value); }
        }

        public bool IsVisible
        {
            get { return this._isVisible; }
            set { SetValue(ref this._isVisible, value); }
        }

        public bool IsEnabled
        {
            get { return this._isEnabled; }
            set { SetValue(ref this._isEnabled, value); }
        }

        public bool IsRunning
        {
            get { return this._isRunning; }
            set { SetValue(ref this._isRunning, value); }
        }
        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }
        #endregion
        #region Procesos
        public ICommand RegisterCommand
        {
            get
            {
                return new RelayCommand(Registro);
            }
        }
        public async void Registro()
        {
            if(string.IsNullOrEmpty(this.Correo))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error","Debes ingresar tu correo electronico","Aceptar"
                );
                return;
            }
            if (string.IsNullOrEmpty(this.NUser))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error", "Debes ingresar un nombre de usuario", "Aceptar"
                );
                return;
            }
            if (string.IsNullOrEmpty(this.Contraseña))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error", "No has ingresado una contraseña todavia", "Aceptar"
                );
                return;
            }
            if (string.IsNullOrEmpty(this.Sexo))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error", "selecciona tu sexo", "Aceptar"
                );
                return;
            }
            if (string.IsNullOrEmpty(Convert.ToString(this.Edad)))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error", "Ingresa tu edad", "Aceptar"
                );
                return;
            }
            string WebAPIKey = "AIzaSyDShqu1iNFJhSy1Jvoqn7vWpwEaUsRFtMM";

            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIKey));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(Correo.ToString(),Contraseña.ToString());
                string gettoken = auth.FirebaseToken;
                InsertMethod();
                await Application.Current.MainPage.DisplayAlert("Correcto", "Bienvenido " + _NUser.ToString() + " a Descubre Nica", "Ok");
                await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
            }
            catch (Exception)
            {
                await App.Current.MainPage.DisplayAlert("Alerta", "Este correo ya esta registrado", "OK");
            }
        }

        private async void InsertMethod()
        {

            var usuario = new MUsers
            {
                NUser = _NUser,
                Edad = _edad,
                Sexo=_Sexo,
                Correo=_Correo,
                Clave=_Contraseña
            };

            await firebaseusers.AddUser(usuario);

            this.IsRefreshing = true;

            

            await Task.Delay(1000);

            _ = LoadData();

            this.IsRefreshing = false;
        }
        public async Task LoadData()
        {
            this.listViewSource = await firebaseusers.GetAllMUsers();
        }
        public async Task NavToLogin()
        {
            await Navigation.PushAsync(new LoginPage());
        }
        #endregion
        #region Comandos
        public ICommand NavToLoginCommand => new Command(async () => await NavToLogin());
        #endregion
    }
}
