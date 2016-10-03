using System;
using System.Collections.Generic;
using System.Text;
using CoreGraphics;
using Foundation;
using UIKit;

namespace Autowont.iOS.Controls
{
    [Register(nameof(CheckBoxControl))]
    public class CheckBoxControl : UIButton
    {

        public CheckBoxControl()
        {
            Initialize();
        }


        public CheckBoxControl(CGRect bounds)
            : base(bounds)
        {
            Initialize();
        }


        public string CheckedTitle
        {
            set
            {
                SetTitle(value, UIControlState.Selected);
            }
        }


        public string UncheckedTitle
        {
            set
            {
                SetTitle(value, UIControlState.Normal);
            }
        }


        public bool Checked
        {
            set { Selected = value; }
            get { return Selected; }
        }


        void Initialize()
        {
            AdjustEdgeInsets();
            ApplyStyle();

            TouchUpInside += (sender, args) => Selected = !Selected;
        }


        void AdjustEdgeInsets()
        {
            const float Inset = 8f;

            HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
            ImageEdgeInsets = new UIEdgeInsets(0f, Inset, 0f, 0f);
            TitleEdgeInsets = new UIEdgeInsets(0f, Inset * 2, 0f, 0f);
        }


        void ApplyStyle()
        {
            SetImage(UIImage.FromBundle("checked_checkbox.png").ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate), UIControlState.Selected);
            SetImage(UIImage.FromBundle("unchecked_checkbox.png").ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate), UIControlState.Normal);
        }
    }
}
