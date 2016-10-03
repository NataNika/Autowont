using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Autowont.Pages
{
    public partial class DrawerMenuPage : AWPage
    {
        public static readonly BindableProperty BadgeValueProperty = BindableProperty.Create("BadgeValue", typeof(string), typeof(DrawerMenuPage), null);

        public string BadgeValue { get { return GetValue(BadgeValueProperty) as string; } set { SetValue(BadgeValueProperty, value); } }

        public DrawerMenuPage()
        {
            InitializeComponent();
        }
    }
}
