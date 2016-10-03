using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autowont.Services;

namespace Autowont.ViewModels
{
    public abstract class TabbedViewModel<TViewModel1, TViewModel2> : ViewModel, ITabbedViewModel
        where TViewModel1 : IViewModel
        where TViewModel2 : IViewModel
    {
        public TabbedViewModel(IApp app, IDialogsService dialogsService, INavigationService navigationService)
            : base(app, dialogsService, navigationService)
        {
            ChildViewModels = new Dictionary<string, ViewModel>();
        }

        public IDictionary<string, ViewModel> ChildViewModels { get; set; }

        public event EventHandler<ViewModelSelectionArgs> SelectedPageChange;

        public void SelectTab(Type viewModelType)
        {
            if (SelectedPageChange != null)
                SelectedPageChange.Invoke(this, new ViewModelSelectionArgs { SelectedViewModelType = viewModelType });
        }

        public virtual void OnSelectedTabChanged(ViewModel selectedViewModel)
        {
        }
    }

    public abstract class TabbedViewModel<TViewModel1, TViewModel2, TViewModel3> : ViewModel, ITabbedViewModel
        where TViewModel1 : IViewModel
        where TViewModel2 : IViewModel
        where TViewModel3 : IViewModel
    {
        public TabbedViewModel(IApp app, IDialogsService dialogsService, INavigationService navigationService)
            : base(app, dialogsService, navigationService)
        {
            ChildViewModels = new Dictionary<string, ViewModel>();
        }

        public IDictionary<string, ViewModel> ChildViewModels { get; set; }

        public event EventHandler<ViewModelSelectionArgs> SelectedPageChange;

        public void SelectTab(Type viewModelType)
        {
            if (this.SelectedPageChange != null)
                this.SelectedPageChange.Invoke(this, new ViewModelSelectionArgs { SelectedViewModelType = viewModelType });
        }

        public virtual void OnSelectedTabChanged(ViewModel selectedViewModel)
        {
        }
    }

    public abstract class TabbedViewModel<TViewModel1, TViewModel2, TViewModel3, TViewModel4> : ViewModel, ITabbedViewModel
        where TViewModel1 : IViewModel
        where TViewModel2 : IViewModel
        where TViewModel3 : IViewModel
        where TViewModel4 : IViewModel
    {
        public TabbedViewModel(IApp app, IDialogsService dialogsService, INavigationService navigationService)
            : base(app, dialogsService, navigationService)
        {
            ChildViewModels = new Dictionary<string, ViewModel>();
        }

        public IDictionary<string, ViewModel> ChildViewModels { get; set; }

        public event EventHandler<ViewModelSelectionArgs> SelectedPageChange;

        public void SelectTab(Type viewModelType)
        {
            if (this.SelectedPageChange != null)
                this.SelectedPageChange.Invoke(this, new ViewModelSelectionArgs { SelectedViewModelType = viewModelType });
        }

        public virtual void OnSelectedTabChanged(ViewModel selectedViewModel)
        {
        }
    }

    public abstract class TabbedViewModel<TViewModel1, TViewModel2, TViewModel3, TViewModel4, TViewModel5> : ViewModel, ITabbedViewModel
        where TViewModel1 : IViewModel
        where TViewModel2 : IViewModel
        where TViewModel3 : IViewModel
        where TViewModel4 : IViewModel
        where TViewModel5 : IViewModel
    {
        public TabbedViewModel(IApp app, IDialogsService dialogsService, INavigationService navigationService)
            : base(app, dialogsService, navigationService)
        {
            ChildViewModels = new Dictionary<string, ViewModel>();
        }

        public IDictionary<string, ViewModel> ChildViewModels { get; set; }

        public event EventHandler<ViewModelSelectionArgs> SelectedPageChange;

        public void SelectTab(Type viewModelType)
        {
            if (this.SelectedPageChange != null)
                this.SelectedPageChange.Invoke(this, new ViewModelSelectionArgs { SelectedViewModelType = viewModelType });
        }

        public virtual void OnSelectedTabChanged(ViewModel selectedViewModel)
        {
        }
    }

    public abstract class TabbedViewModel<TViewModel1, TViewModel2, TViewModel3, TViewModel4, TViewModel5, TViewModel6> : ViewModel, ITabbedViewModel
        where TViewModel1 : IViewModel
        where TViewModel2 : IViewModel
        where TViewModel3 : IViewModel
        where TViewModel4 : IViewModel
        where TViewModel5 : IViewModel
        where TViewModel6 : IViewModel
    {
        public TabbedViewModel(IApp app, IDialogsService dialogsService, INavigationService navigationService)
            : base(app, dialogsService, navigationService)
        {
            ChildViewModels = new Dictionary<string, ViewModel>();
        }

        public IDictionary<string, ViewModel> ChildViewModels { get; set; }

        public event EventHandler<ViewModelSelectionArgs> SelectedPageChange;

        public void SelectTab(Type viewModelType)
        {
            if (this.SelectedPageChange != null)
                this.SelectedPageChange.Invoke(this, new ViewModelSelectionArgs { SelectedViewModelType = viewModelType });
        }

        public virtual void OnSelectedTabChanged(ViewModel selectedViewModel)
        {
        }
    
    }
}
