using Descubre_Nica.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Descubre_Nica.ViewModel
{
    internal class VMContacto:BaseViewModel
    {
        #region Variables
        public string _Texto;
        #endregion
        #region Constructores
        public VMContacto(INavigation navigation)
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
        public async Task NavContacto()
        {
            await Navigation.PushAsync(new Contacto());
        }
        public async Task Backpage()
        {
            await Navigation.PopAsync();
        }
        public void ProcesoSimple()
        {

        }
        #endregion
        #region Comandos
        public ICommand NaveContactoCommand => new Command(async () => await NavContacto());
        public ICommand BackPageCommand => new Command(async () => await Backpage());
        public ICommand ProcesoSimpCommand => new Command(ProcesoSimple);
        #endregion
    }
}
