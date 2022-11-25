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
    public class VMSelDptoPage : BaseViewModel
    {
        FirebaseDeptos firebasedeptos = new FirebaseDeptos();

        #region Variables
        public bool isRefreshing = false;
        public object listViewSource;
        #endregion
        #region Constructores
        public VMSelDptoPage(INavigation navigation)
        {
            Navigation = navigation;
        }
        public VMSelDptoPage()
        {
            _=LoadData();
        }
        #endregion
        #region Objetos

        
        public object ListViewSource
        {

            get { return this.listViewSource; }
            set
            {
                SetValue(ref this.listViewSource, value);
            }
        }
        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
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
            this.ListViewSource = await firebasedeptos.GetAllMDepartamentos();
        }

        #endregion
        #region Comandos
        public ICommand commandAceptar => new Command(async () => await BTAceptar());
        public ICommand commandSiteInfo => new Command(async () => await BTSiteInfo());
        public ICommand BackCommand => new Command(async () => await Volver());
        #endregion

    }
}
