using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Autofac;
using Autowont.Services;
using Autowont.ViewModels.Base;
using Xamarin.Forms.Platform.Android;

//[assembly: Permission(Name = Android.Manifest.Permission.Internet)]
//[assembly: Permission(Name = Android.Manifest.Permission.WriteExternalStorage)]

namespace Autowont.Droid
{
    [Activity(Label = "Autowont", Icon = "@drawable/icon", Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private App _app;

        private INavigationService _navigation;
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}

