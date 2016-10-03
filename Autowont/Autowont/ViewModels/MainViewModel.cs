using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autowont.Services;

namespace Autowont.ViewModels
{
    public class MainViewModel : TabbedViewModel<SearchViewModel, MessagesViewModel, HistoryViewModel, FavoriteViewModel, AccountViewModel>
    {
        public MainViewModel(IApp app, IDialogsService dialogsService, INavigationService navigationService) : base(app, dialogsService, navigationService)
        {
            
        }

        public override void Init(object args)
        {
            base.Init(args);
            var viewModelType = args as Type;
            if (viewModelType != null)
            {
                SelectTab(viewModelType);
            }
        }
        public override Type DrawerMenuViewModelType => typeof(DrawerMenuViewModel);
    }


}
