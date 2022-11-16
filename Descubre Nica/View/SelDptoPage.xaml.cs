using Descubre_Nica.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Descubre_Nica.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelDptoPage : ContentPage
    {
        public SelDptoPage()
        {
            InitializeComponent();
            BindingContext = new VMSelDptoPage(Navigation);  
        }
    }
}