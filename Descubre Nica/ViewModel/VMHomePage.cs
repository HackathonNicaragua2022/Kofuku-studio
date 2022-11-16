using Descubre_Nica.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Descubre_Nica.ViewModel
{
    internal class VMHomePage:BaseViewModel
    {
        #region Variables
        public string _Texto;
        #endregion
        #region Constructores
        public VMHomePage(INavigation navigation)
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
        public async Task Navegar()
        {
            await Navigation.PushAsync(new HistorialPage());
        }
        public void ProcesoSimple()
        {

        }
        #endregion
        #region Comandos
        public ICommand NavHisPageCommand => new Command(async () => await Navegar());
        public ICommand ProceCommand => new Command(ProcesoSimple);
        #endregion

    }
}
