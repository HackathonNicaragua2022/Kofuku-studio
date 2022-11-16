using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Descubre_Nica.ViewModel;


namespace Descubre_Nica.ViewModel
{
    public class VMMainPage: BaseViewModel
    {

        #region Variables
        public string _Texto;
        #endregion
        #region Constructores
        public VMMainPage(INavigation navigation)
        {
            Transparente();
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
        public void Transparente()
        {
            DependencyService.Get<VMStatusBar>().Transparente();
        }
        #endregion
        #region Comandos
        public ICommand ProcesoAsyncCommand => new Command(async () => await ProcesoAsyncrono());
        public ICommand TransparenteCommand => new Command(Transparente);
        #endregion

    }
}
