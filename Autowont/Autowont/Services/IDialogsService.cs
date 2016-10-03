using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autowont.Services
{
    public interface IDialogsService
    {
        void Alert(string message, string title = null, string closeButton = null);

        Task AlertAsync(string message, string title = null, string closeButton = null);

        Task<bool> QuestionAsync(string message, string title = null, string acceptButton = null, string cancelButton = null);

        Task<string> ActionMenu(string title, string cancel, string destruction, string[] items);

        void ShowLoading(string title);

        void HideLoading();
    }
}
