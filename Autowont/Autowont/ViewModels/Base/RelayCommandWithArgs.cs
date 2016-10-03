using System;
using Xamarin;
using Autofac;
using Autowont.Services;

namespace Autowont.ViewModels
{
    public class RelayCommandWithArgs<T> : BaseCommand
    {

        public override void Execute(object parameter)
        {
            try
            {
                actionExecute.Invoke((T)parameter);
                successCommand = true;
            }
            catch (Exception ex)
            {
                if (vmodel == null)
                {
                    var app = App.Current as App;
                    var dialogsService = app.Container.Resolve<IDialogsService>();
                    dialogsService.Alert(ex.Message);
                }
                successCommand = false;
            }
        }

        public RelayCommandWithArgs(Action<T> action, ViewModel vm, string message = null)
            : base(vm, message)
        {
            actionExecute = action;
        }

        private Action<T> actionExecute;
    }
}
