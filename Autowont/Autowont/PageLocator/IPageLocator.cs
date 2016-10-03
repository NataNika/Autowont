using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autowont.ViewModels;
using Xamarin.Forms;

namespace Autowont.PageLocator
{
    public interface IPageLocator
    {
        Page ResolvePageAndViewModel(Type viewModelType, object args = null);

        Page ResolvePage(IViewModel viewModel);

        Type ResolvePageType(Type viewmodel);
    }
}
