using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Descubre_Nica.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
            this.BindingContext = this;
        }

        private Timer timer;

        public ObservableCollection<Walkthrough> WalkthroughItems { get => Load(); }


        protected override void OnAppearing()
        {
            timer = new Timer(TimeSpan.FromSeconds(5).TotalMilliseconds) { AutoReset = true, Enabled = true };
            timer.Elapsed += Timer_Elapsed;
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            timer?.Dispose();
            base.OnDisappearing();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {

                if (cvWalkthrough.Position == 4)
                {
                    cvWalkthrough.Position = 0;
                    return;
                }

                cvWalkthrough.Position += 1;
            });
        }

        private ObservableCollection<Walkthrough> Load()
        {
            return new ObservableCollection<Walkthrough>(new[]
            {
                new Walkthrough
                {
                    Heading ="Volcan",
                    Caption = " info",
                    Image = "Volcan.jpg"
                },

                new Walkthrough
                {
                    Heading ="BocaVolcan.jpg",
                    Caption = " info",
                    Image = "BocaVolcan.jpg"
                },

                new Walkthrough
                {
                    Heading ="Playa.jpg",
                    Caption = " info",
                    Image = "Playa.jpg"
                },

                new Walkthrough
                {
                    Heading ="Cañon.jpg",
                    Caption = " info",
                    Image = "Canon.jpg"
                }
                ,

                new Walkthrough
                {
                    Heading ="Catedral.jpg",
                    Caption = " info",
                    Image = "Catedral.jpg"
                }
            });
        }
        public async Task NavToLogin()
        {
            string band = "1";

            Application.Current.Properties["banda"] = band;
            await Navigation.PushAsync(new LoginPage());
            

        }

        public ICommand NavToLoginCommand => new Command(async () => await NavToLogin());
    }

    public class Walkthrough
    {
        public string Heading { get; set; }
        public string Caption { get; set; }
        public string Image { get; set; }
    }
}