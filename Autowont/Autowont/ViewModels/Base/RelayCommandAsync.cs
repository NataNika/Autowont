using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autowont.Services;
using Autofac;

namespace Autowont.ViewModels
{
    public class RelayCommandAsync : BaseCommand
    {
        public RelayCommandAsync(Func<Task> action, IViewModel vModel, string message = null) : base(vModel, message)
        {
            executeActionAsync = action;
        }

        public override async void Execute(object parameter)
        {
            try
            {
                if (executeActionAsync != null)
                    await executeActionAsync.Invoke();
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

        private Func<Task> executeActionAsync;
    }
}
