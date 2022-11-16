using Descubre_Nica.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Descubre_Nica.ViewModel
{
    internal class VMBagPage:BaseViewModel
    {

        #region Variables
        public string _Texto;
        #endregion
        #region Constructores
        public VMBagPage(INavigation navigation)
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
        public async Task BTPlanearGira()
        {
            await Navigation.PushAsync(new SelDptoPage());
        }
        public void ProcesoSimple()
        {

        }
        #endregion
        #region Comandos
        public ICommand commandPlanearGira => new Command(async () => await BTPlanearGira());
        public ICommand ProcesoSimpCommand => new Command(ProcesoSimple);
        #endregion

    }
}
