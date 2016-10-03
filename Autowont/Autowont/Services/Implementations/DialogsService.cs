using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;

namespace Autowont.Services
{
    public class DialogsService : IDialogsService
    {

        IApp _app;

        public DialogsService(IApp app)
        {
            this._app = app;
        }

        public void Alert(string message, string title = null, string closeButton = null)
        {
            //if (!_app.IsVisible)
            //    return;

            if (closeButton.IsNullOrEmpty())
                closeButton = "OK";

            UserDialogs.Instance.Alert(message, title, closeButton);
        }

        public Task AlertAsync(string message, string title = null, string closeButton = null)
        {
            //if (!_app.IsVisible)
            //    return Task.FromResult(0);

            if (closeButton.IsNullOrEmpty())
                closeButton = "OK"; 

            return UserDialogs.Instance.AlertAsync(message, title, closeButton);
        }

        public Task<bool> QuestionAsync(string message, string title = null, string acceptButton = null, string cancelButton = null)
        {
            //if (!_app.IsVisible)
            //    return Task.FromResult(false);

            if (string.IsNullOrEmpty(acceptButton))
                acceptButton = "OK"; 

            if (string.IsNullOrEmpty(cancelButton))
                acceptButton = "Cancel";

            return UserDialogs.Instance.ConfirmAsync(message, title, acceptButton, cancelButton);
        }

        public Task<string> ActionMenu(string title, string cancel, string destruction, string[] items)
        {
            //if (!_app.IsVisible)
            //    return Task.FromResult(string.Empty);

            if (items != null)
                return _app.MainPage.DisplayActionSheet(title, cancel, destruction, items);

            if (string.IsNullOrEmpty(destruction))
                return new Task<string>(() => string.Empty);

            return UserDialogs.Instance.ActionSheetAsync(title, cancel, destruction);
        }

        public void ShowLoading(string title)
        {
            //if (!_app.IsVisible)
            //    return;

            UserDialogs.Instance.ShowLoading(title);
        }

        public void HideLoading()
        {
            //if (!_app.IsVisible)
            //    return;
            UserDialogs.Instance.HideLoading();
        }
    }
}
