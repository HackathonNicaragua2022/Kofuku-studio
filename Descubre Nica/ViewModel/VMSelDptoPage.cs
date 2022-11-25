using Descubre_Nica.Services;
using Descubre_Nica.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Descubre_Nica.ViewModel
{
    internal class VMSelDptoPage : BaseViewModel
    {
        FirebaseDeptos firebasedeptos = new FirebaseDeptos();

        #region Variables
        public object listViewSource;

        public string _nombre;
        #endregion
        #region Constructores
        public VMSelDptoPage(INavigation navigation)
        {
            Navigation = navigation;
        }
        public VMSelDptoPage()
        {
            _ = LoadData();
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
        public async Task LoadData()
        {
            this.listViewSource = await firebasedeptos.GetAllMDepartamentos();
        }

        #endregion
        #region Comandos
        public ICommand CommandAceptar => new Command(async () => await BTAceptar());
        public ICommand CommandSiteInfo => new Command(async () => await BTSiteInfo());
        public ICommand BackCommand => new Command(async () => await Volver());
        #endregion

    }
}
