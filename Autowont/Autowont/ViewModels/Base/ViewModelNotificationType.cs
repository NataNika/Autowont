using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autowont.ViewModels
{
    public enum ViewModelNotificationType
    {
        LocalRefresh = 0,
        ReSync,
        Pop,
        PopIfTop,
        LoginCompleted,
        CheckForProfilePictures
    }
}
