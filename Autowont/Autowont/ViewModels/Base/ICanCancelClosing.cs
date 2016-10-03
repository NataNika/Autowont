using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autowont.ViewModels.Base
{
    public interface ICanCancelClosing
    {
        string CancelTitle { get; }

        Task<bool> CanClose();
    }
}
