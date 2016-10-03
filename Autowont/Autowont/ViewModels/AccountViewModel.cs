using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autowont.Services;

namespace Autowont.ViewModels
{
    public class AccountViewModel: ViewModel
    {
        public AccountViewModel(IApp app, IDialogsService dialogsService, INavigationService navigationService) : base(app, dialogsService, navigationService)
        {
            Title = "Аккаунт";
            Icon = "accountIcon";
        }
    }
}
