using CommunityToolkit.Mvvm.Input;
using Descubre_Nica.Model;
using Descubre_Nica.Services;
using Descubre_Nica.View;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Descubre_Nica.ViewModel
{
    public class VMSelDptoPage : BaseViewModel
    {
        FirebaseDeptos firebasedeptos = new FirebaseDeptos();

        #region Variables
        public bool isRefreshing = false;
        public string _nombre;
        public ObservableCollection<MDepartamentos> listViewSource;
        #endregion
        #region Constructores
        public VMSelDptoPage(INavigation navigation)
        {
            Navigation = navigation;
            MostrarDepartamentos();
        }
        #endregion
        #region Objetos


        public ObservableCollection<MDepartamentos> ListViewSource
        {

            get { return this.listViewSource; }
            set
            {
                SetValue(ref this.listViewSource, value);
                OnPropertyChanged();
            }
        }
        
        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { SetValue(ref this._nombre, value); }
        }
        #endregion
        #region Procesos
        public async Task MostrarDepartamentos()
        {
            var funcion = new FirebaseDeptos();
            ListViewSource = await funcion.MostrarDepartamentos();
        }
        public async Task BTAceptar()
        {
            await Navigation.PushAsync(new GiraPage());
        }

        public async Task BTSiteInfo()
        {
            await Navigation.PushAsync(new SiteInfoPage());
        }
        public async Task Volver()
        {
            await Navigation.PopAsync();
        }

        

        #endregion
        #region Comandos
        public ICommand commandAceptar => new Command(async () => await BTAceptar());
        public ICommand commandSiteInfo => new Command(async () => await BTSiteInfo());
        public ICommand BackCommand => new Command(async () => await Volver());
        
        #endregion

    }
}
