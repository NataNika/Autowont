using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autowont.Models;
using Autowont.ViewModels;
using Xamarin.Forms;

namespace Autowont.Services
{
    public interface INavigationService
    {
        void SetMainViewModel<T>(object args = null) where T : IViewModel;

        Task NavigateToAsync<T>(object args = null) where T : IViewModel;

        Task NavigateToAsync<T1, T2>(object args1 = null, object args2 = null) where T1 : IViewModel where T2 : IViewModel;

        Task NavigateToAsync<T1, T2, T3>(object args1 = null, object args2 = null, object args3 = null) where T1 : IViewModel where T2 : IViewModel where T3 : IViewModel;

        Task NavigateToModalAsync<T>(object args = null) where T : IViewModel;

        Task PopAsync();

        Task PopModalAsync();

        Task PopToRootAsync();

        Page ResolvePageFor<T>(object args = null) where T : IViewModel;

        void RemoveFromNavigationStack<T>(bool removeFirstOccurenceOnly = true) where T : IViewModel;

        IReadOnlyList<IViewModel> GetNavigationStack();

        void NotifyViewModel<T>(object sender, ViewModelNotificationType notificationType, object args = null) where T : IViewModel;

        bool IsRootPage { get; }

        IViewModel CurrentViewModel { get; }

        Page CurrentPage { get; }

        void OpenDrawerMenu();

        void CloseDrawerMenu();

        void ToggleDrawerMenu();
    }
}
