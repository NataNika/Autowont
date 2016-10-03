using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autowont.Services;

namespace Autowont.ViewModels
{
    public class SettingsViewModel : ViewModel
    {
        public SettingsViewModel(IApp app, IDialogsService dialogsService, INavigationService navigationService) : base(app, dialogsService, navigationService)
        {
            Title = "Настройки";
            Icon = "settingsIcon";
        }
    }
}
