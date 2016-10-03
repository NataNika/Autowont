using System;
using Xamarin.Forms;
using Autowont.Pages;
using Xamarin.Forms.Platform.Android;
using Android.Support.V7.Widget;
using Android.Graphics.Drawables;
using TextView = Android.Widget.TextView;

[assembly: ExportRenderer(typeof(DrawerMenuPage), typeof(Autowont.Droid.Renderers.DrawerMenuPageRenderer))]
namespace Autowont.Droid.Renderers
{
    public class DrawerMenuPageRenderer : PageRenderer
    {

        //TextView badgeView;

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            if (Element != null /*&& badgeView == null*/)
            {
                //var toolbar = MainActivity.Instance.FindViewById<Toolbar>(Resource.Id.toolbar);

                // Comment because with this layout page title not shown
                //badgeView = toolbar.FindViewById(Resource.Id.badgeView) as TextView;

                //if (badgeView != null)
                //                SetBadgeText();
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            //if (e.PropertyName == DrawerMenuPage.BadgeValueProperty.PropertyName)
            //    SetBadgeText();
        }

        //private void SetBadgeText()
        //{
        //    if (badgeView == null)
        //        return;

        //    var drawerPage = Element as DrawerMenuPage;

        //    if (string.IsNullOrEmpty(drawerPage.BadgeValue) || drawerPage.BadgeValue == "0")
        //        badgeView.Visibility = Android.Views.ViewStates.Invisible;
        //    else
        //    {
        //        badgeView.Visibility = Android.Views.ViewStates.Visible;
        //        badgeView.Text = drawerPage.BadgeValue;
        //    }
        //}



    }
}