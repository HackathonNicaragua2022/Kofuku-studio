using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Descubre_Nica.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Descubre_Nica.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Contacto : ContentPage
    {
        public Contacto()
        {
            InitializeComponent();
            BindingContext = new VMContacto(Navigation);
        }
    }
}