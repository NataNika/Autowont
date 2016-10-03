using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autowont.Services;

namespace Autowont.ViewModels
{
    public class MessagesViewModel : ViewModel
    {
        public MessagesViewModel(IApp app, IDialogsService dialogsService, INavigationService navigationService) : base(app, dialogsService, navigationService)
        {
            Title = "Сообщения";
            Icon = "messageIcon";
        }
    }
}
