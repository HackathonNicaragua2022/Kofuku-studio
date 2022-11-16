using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plugin.CurrentActivity;
using Xamarin.Forms;
using Descubre_Nica.Droid.StatusBar;
using Descubre_Nica.ViewModel;

[assembly:Dependency(typeof(StatusBar))]
namespace Descubre_Nica.Droid.StatusBar
{
    internal class StatusBar : VMStatusBar
    {
        WindowManagerFlags _originalFlags;
        Window GetCurrentWindow()
        {
            var window = CrossCurrentActivity.Current.Activity.Window;
            window.ClearFlags(WindowManagerFlags.TranslucentStatus);
            window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
            return window;
        }
        public void CambiarColor()
        {
            if(Build.VERSION.SdkInt>=BuildVersionCodes.M)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    var currentWindow = GetCurrentWindow();
                    currentWindow.DecorView.SystemUiVisibility = (StatusBarVisibility)SystemUiFlags.LayoutStable;
                    currentWindow.SetStatusBarColor(Android.Graphics.Color.Rgb(18, 18, 18));
                });
            }
        }

        public void Mostrar()
        {
            var activity = (Activity)Forms.IsInitialized;
            var attribs = activity.Window.Attributes;
            attribs.Flags = _originalFlags;
            activity.Window.Attributes = attribs;
        }

        public void Ocultar()
        {
            var activity = (Activity)Forms.IsInitialized;
            var attribs = activity.Window.Attributes;
            _originalFlags = attribs.Flags;
            attribs.Flags = WindowManagerFlags.Fullscreen;
            activity.Window.Attributes = attribs;
        }

        public void Transparente()
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    var currentWindow = GetCurrentWindow();
                    currentWindow.DecorView.SystemUiVisibility = (StatusBarVisibility)SystemUiFlags.LayoutFullscreen;
                    currentWindow.SetStatusBarColor(Android.Graphics.Color.Transparent);
                });
            }
        }

        public void Traslucido()
        {
            var activity = (Activity)Forms.IsInitialized;
            var attribs = activity.Window.Attributes;
            _originalFlags = attribs.Flags;
            attribs.Flags = ~WindowManagerFlags.TranslucentStatus;
            activity.Window.Attributes = attribs;
        }
    }
}