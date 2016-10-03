using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Autowont.ViewModels
{
    public class BaseCommand: ICommand
    {
        public bool Succes
        {
            get
            {
                return this.successCommand;
            }
        }

        public BaseCommand(IViewModel vm, string message = null)
        {
            this.vmodel = vm;
            this._message = message;

        }

        #region ICommand implementation

#pragma warning disable 0067
        public event EventHandler CanExecuteChanged;
#pragma warning restore 0067


        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        public virtual void Execute(object parameter)
        {

        }

        public virtual async Task ExecuteAsync(object parameter)
        {
            await Task.FromResult(0);
        }

        #endregion

        protected string _message;
        protected IViewModel vmodel;
        protected bool successCommand;
    }
}
