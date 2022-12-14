using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Descubre_Nica.ViewModel
{
    internal class VMSiteInfoPage:BaseViewModel
    {

        #region Variables
        public string _Texto;
        #endregion
        #region Constructores
        public VMSiteInfoPage(INavigation navigation)
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
        public async Task Volver()
        {
            await Navigation.PopAsync();
        }
        public void ProcesoSimple()
        {

        }
        #endregion
        #region Comandos
        public ICommand BackCommand => new Command(async () => await Volver());
        public ICommand ProcesoSimpCommand => new Command(ProcesoSimple);
        #endregion

    }
}
