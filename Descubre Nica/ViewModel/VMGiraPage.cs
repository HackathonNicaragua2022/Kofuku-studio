using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Descubre_Nica.ViewModel
{
    internal class VMGiraPage: BaseViewModel
    {

        #region Variables
        public bool _isVisiblerutas=false;
        public bool _isVisiblecomollegar=false;
        #endregion
        #region Constructores
        public VMGiraPage(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion
        #region Objetos
        public bool IsVisibleRutas
        {
            get { return _isVisiblerutas; }
            set { SetValue(ref _isVisiblerutas, value); }
        }
        public bool IsVisibleComoLlegar
        {
            get { return _isVisiblecomollegar; }
            set { SetValue(ref _isVisiblecomollegar, value); }
        }
        #endregion
        #region Procesos
        public void ValidarRutas()
        {
            if(IsVisibleRutas==false)
                this.IsVisibleRutas = true;
            else
                this.IsVisibleRutas=false;
        }
        public void ValidarComoLlegar()
        {
            if (IsVisibleComoLlegar == false)
                this.IsVisibleComoLlegar = true;
            else
                this.IsVisibleComoLlegar = false;
        }
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
        public ICommand IsVisibleRutasCommand => new Command(ValidarRutas);
        public ICommand IsVisibleComoLlegarCommand => new Command(ValidarComoLlegar);
        #endregion

    }
}
