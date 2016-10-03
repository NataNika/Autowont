using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autowont.Services;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Autowont.Helpers;
using Autowont.Models;

namespace Autowont.ViewModels
{
    public abstract class ListViewModel<T> : ViewModel
    {
        public bool SelectionEnabled { get; set; }
        public ListViewModel(IApp app, IDialogsService dialogsService, INavigationService navigationService) : base(app, dialogsService, navigationService)
        {
            SelectionEnabled = true;
        }

        public ObservableCollection<T> Items { get; set; }
        public T SelectedItem
        {
            get { return default(T); }
            set
            {
                if (value != null && SelectionEnabled)
                {
                    ItemTapped.Execute(value);
                    OnPropertyChanged();
                }
            }
        }

        public ICommand ItemTapped
        {
            get
            {
                return new RelayCommandWithArgs<T>(async (args) =>
                {
                    if (args != null)
                        await ItemTappedAsync(args);
                }, this);
            }
        }

        protected abstract Task ItemTappedAsync(T item);

        //public virtual async Task GetLocalDataAsync()
        //{
        //    SearchADVModel items = WebApiHelper.GetObj<SearchADVModel>("/search?&brand=1");
        //    Items = items.advertList as ObservableCollection<T>;
        //}
    }
}
