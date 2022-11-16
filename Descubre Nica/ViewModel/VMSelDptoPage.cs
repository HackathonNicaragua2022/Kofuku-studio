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

        #region Variables
        public string _Texto;
        #endregion
        #region Constructores
        public VMSelDptoPage(INavigation navigation)
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
        public async Task BTAceptar()
        {
            await Navigation.PushAsync(new GiraPage());
        }

        public async Task BTSiteInfo()
        {
            await Navigation.PushAsync(new SiteInfoPage());
        }
        public void ProcesoSimple()
        {

        }
        #endregion
        #region Comandos
        public ICommand commandAceptar => new Command(async () => await BTAceptar());
        public ICommand commandSiteInfo => new Command(async () => await BTSiteInfo());
        public ICommand ProcesoSimpCommand => new Command(ProcesoSimple);
        #endregion

    }
}
