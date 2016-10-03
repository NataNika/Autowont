using System;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using Autowont.Services;
using Xamarin.Forms;

namespace Autowont.ViewModels
{
    public abstract class ViewModel : AbstractNpcObject, IViewModel
	{
		private object _initArgs;

        protected readonly IApp App;

        protected readonly IDialogsService Dialogs;

        protected readonly INavigationService Navigation;

        private bool started;

        protected ViewModel(IApp app, IDialogsService dialogsService,
            INavigationService navigationService)
        {
            App = app;
            Dialogs = dialogsService;
            Navigation = navigationService;
            this.ToolbarItems = new ObservableCollection<ToolbarItem>();

            Title = string.Empty; // so we don't forget to set a title ;-)
        }


        public bool IsVisible { get; private set; }

        public bool IsOffline { get; private set; }

        public ITabbedViewModel ParentViewModel { get; set; }

        public bool IsBusy { get; set; }

        public string Title { get; set; }

        public string Icon { get; set; }

        public string Badge { get; set; }

        
        public virtual Type DrawerMenuViewModelType => null;

        public virtual Type PageType
        {
            get { return null; }
        }


        public ObservableCollection<ToolbarItem> ToolbarItems { get; set; }


        public virtual void Init(object args)
        {
            _initArgs = args;
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (propertyName == null)
                return;

            base.OnPropertyChanged(propertyName);

            if (propertyName == nameof(Badge))
            {
                OnBadgeChange();
            }
        }

        public event Action<ViewModel> BadgeChange;

        public void OnBadgeChange()
        {
            BadgeChange?.Invoke(this);
        }

        public virtual void OnStart()
        {
            started = true;
        }

        public virtual void OnAppearing()
        {
            IsVisible = true;

            if (!started)
            {
                started = true;
                OnStart();
            }
        }

	    public virtual void OnDisappearing()
	    {
	        IsVisible = false;
	    }

        public virtual void OnClosing()
        {
            started = false;
        }

        
    }
}
