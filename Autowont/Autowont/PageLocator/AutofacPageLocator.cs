using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autowont.Pages;
using Autowont.ViewModels;

namespace Autowont.PageLocator
{
    public class AutofacPageLocator : PageLocator
    {
        private readonly ILifetimeScope container;

        public AutofacPageLocator(ILifetimeScope container)
        {
            this.container = container;
        }

        protected override IAWPage CreatePage(Type pageType)
        {
            return this.container.Resolve(pageType) as IAWPage;
        }

        protected override IViewModel CreateViewModel(Type viewModelType)
        {
            return this.container.Resolve(viewModelType) as IViewModel;
        }
    }
}
