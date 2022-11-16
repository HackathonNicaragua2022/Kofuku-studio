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
        public async Task ProcesoAsyncrono()
        {
            await DisplayAlert("titulo", "mensaje", "cancelar");
        }
        public void ProcesoSimple()
        {

        }
        #endregion
        #region Comandos
        public ICommand ProcesoAsyncCommand => new Command(async () => await ProcesoAsyncrono());
        public ICommand ProcesoSimpCommand => new Command(ProcesoSimple);
        #endregion

    }
}
