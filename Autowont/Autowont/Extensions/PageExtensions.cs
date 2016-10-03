using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autowont.Pages;
using Autowont.ViewModels;
using Xamarin.Forms;

namespace Autowont
{
    public static class PageExtensions
    {
        public static void BindViewModel(this IAWPage page, IViewModel viewModel)
        {
            page.BindingContext = viewModel;
            page.SetBinding<IViewModel>(Page.IsBusyProperty, x => x.IsBusy);
            page.SetBinding<IViewModel>(Page.TitleProperty, x => x.Title);
            page.SetBinding<IViewModel>(Page.IconProperty, x => x.Icon);


            page.Appearing += (sender, args) => viewModel.OnAppearing();
            page.Disappearing += (sender, args) => viewModel.OnDisappearing();
            page.PageClosing += (sender, args) => viewModel.OnClosing();
        }
    }
}
