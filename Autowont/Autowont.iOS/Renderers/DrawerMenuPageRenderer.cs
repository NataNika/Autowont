using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using Autowont.Pages;
using Autowont.iOS.Controls;
using CoreGraphics;

[assembly: ExportRenderer(typeof(DrawerMenuPage), typeof(Autowont.iOS.Renderers.DrawerMenuPageRenderer))]
namespace Autowont.iOS.Renderers
{
    public class DrawerMenuPageRenderer : PageRenderer
    {

        BadgeBarButtonItem badgeMenuItemButton;

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);


        }

        void Element_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

            var page = Element as DrawerMenuPage;


            if (badgeMenuItemButton == null || page == null)
                return;


            if (e.PropertyName == DrawerMenuPage.BadgeValueProperty.PropertyName)
                badgeMenuItemButton.BadgeValue = page.BadgeValue;

        }



        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);

            Element.PropertyChanged -= Element_PropertyChanged;
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            Element.PropertyChanged += Element_PropertyChanged;

            if (NavigationController != null && NavigationController.TopViewController != null)
            {

                var menuButton = new UIButton(new CGRect(0, 0, 22, 22));
                menuButton.Font = UIFont.SystemFontOfSize(34);
                menuButton.SetTitle("≡", UIControlState.Normal);
                menuButton.SetTitleColor(UIColor.Gray, UIControlState.Normal);
                menuButton.SetTitleColor(UIColor.Gray, UIControlState.Highlighted);

                badgeMenuItemButton = new BadgeBarButtonItem(menuButton);


                var page = Element as DrawerMenuPage;

                if (page != null)
                    badgeMenuItemButton.BadgeValue = page.BadgeValue;


                menuButton.TouchUpInside += (s, e) =>
                {
                    var masterPage = this.Element.Parent as MasterDetailPage;

                    if (masterPage != null)
                        masterPage.IsPresented = !masterPage.IsPresented;

                };



                NavigationController.TopViewController.NavigationItem.SetLeftBarButtonItem(badgeMenuItemButton, true);

            }

        }
    }
}