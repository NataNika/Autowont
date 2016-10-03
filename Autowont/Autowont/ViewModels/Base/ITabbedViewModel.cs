using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autowont.ViewModels
{
    public interface ITabbedViewModel : IViewModel
    {

        event EventHandler<ViewModelSelectionArgs> SelectedPageChange;

        IDictionary<string, ViewModel> ChildViewModels { get; set; }

        void SelectTab(Type viewModelType);

        void OnSelectedTabChanged(ViewModel selectedViewModel);
    }

    public class ViewModelSelectionArgs
    {
        public Type SelectedViewModelType { get; set; }
    }
}
