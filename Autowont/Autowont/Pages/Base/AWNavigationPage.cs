using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Autowont.Pages.Base
{
    public class AWNavigationPage : NavigationPage
    {
        public AWNavigationPage(Page root) : base(root)
		{

        }

        protected override void OnAppearing()
        {
            this.Popped += Page_Popped;
            base.OnAppearing();
        }

        void Page_Popped(object sender, NavigationEventArgs e)
        {
            var page = e.Page;

            if (page is IAWPage)
                ((IAWPage)page).OnPageClosing();
        }

        protected override void OnDisappearing()
        {
            this.Popped -= Page_Popped;
            base.OnDisappearing();
        }
    }
}
