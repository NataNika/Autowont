using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.ComponentModel;

namespace Autowont.ViewModels
{
    public interface IViewModel: INotifyPropertyChanged
    {
        void Init(object args);

        void OnAppearing();

        void OnDisappearing();

        void OnClosing();

        bool IsBusy { get; set; }

        string Title { get; set; }

        string Icon { get; set; }

        ObservableCollection<ToolbarItem> ToolbarItems { get; set; }

        Type PageType { get; }

        Type DrawerMenuViewModelType { get; }
    }
}
