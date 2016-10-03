using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autowont.Models;
using Autowont.PageLocator;
using Autowont.Pages;
using Autowont.Pages.Base;
using Autowont.ViewModels;
using Xamarin.Forms;

namespace Autowont.Services
{
    public class NavigationService : INavigationService
    {

        protected IApp App { get; private set; }
        protected INavigation Navigation { get; private set; }
        protected IPageLocator PageLocator { get; private set; }

        public NavigationService(IApp app, IPageLocator pageLocator)
        {
            this.App = app;
            this.PageLocator = pageLocator;
        }

        public void SetMainViewModel<T>(object args = null) where T : IViewModel
        {

            var page = ResolvePageFor<T>(args);

            if (page == null)
                throw new Exception("Resolve page for " + typeof(T).Name + " returned null!");

            var masterDetailPage = page as MasterDetailPage;

            if (masterDetailPage != null)
            {

                masterDetailPage.Detail = new AWNavigationPage(masterDetailPage.Detail);
                Navigation = masterDetailPage.Detail.Navigation;
                App.MainPage = masterDetailPage;
            }
            else
            {
                var navigationPage = new AWNavigationPage(page);
                Navigation = navigationPage.Navigation;
                App.MainPage = navigationPage;
            }
        }

        public async Task NavigateToAsync<T>(object args = null) where T : IViewModel
        {
            var page = ResolvePageFor<T>(args);
            if (page == null)
            {
                var msg = "No page found for args: " + args == null
                    ? "null" :
                    args.GetType() + " " + args;
                return;
            }
            await Navigation.PushAsync(page);
        }

        public async Task NavigateToAsync<T1, T2>(object args1 = null, object args2 = null)
            where T1 : IViewModel
            where T2 : IViewModel
        {
            var page1 = ResolvePageFor<T1>(args1);
            var page2 = ResolvePageFor<T2>(args2);

            await Navigation.PushAsync(page1);

            Navigation.InsertPageBefore(page2, page1);
        }

        public async Task NavigateToAsync<T1, T2, T3>(object args1 = null, object args2 = null, object args3 = null)
            where T1 : IViewModel
            where T2 : IViewModel
            where T3 : IViewModel
        {
            var page1 = ResolvePageFor<T1>(args1);
            var page2 = ResolvePageFor<T2>(args2);
            var page3 = ResolvePageFor<T3>(args3);

            await Navigation.PushAsync(page1);

            Navigation.InsertPageBefore(page2, page1);
            Navigation.InsertPageBefore(page3, page2);
        }

        public Task NavigateToModalAsync<T>(object args = null) where T : IViewModel
        {
            var page = ResolvePageFor<T>(args);

            return Navigation.PushModalAsync(page);
        }

        public Task PopAsync()
        {
            return Navigation.PopAsync();
        }

        public Task PopModalAsync()
        {
            return Navigation.PopModalAsync();
        }

        public Task PopToRootAsync()
        {
            return Navigation.PopToRootAsync();
        }

        public Page ResolvePageFor<T>(object args = null) where T : IViewModel
        {
#if DEBUG
            Debug.WriteLine("Resolving page for VM " + typeof(T).Name);
            var sw = new Stopwatch();
            sw.Start();
#endif

            var page = PageLocator.ResolvePageAndViewModel(typeof(T), args);

#if DEBUG
            sw.Stop();
            Debug.WriteLine("Page resolved in " + sw.ElapsedMilliseconds + "ms");
#endif

            return page;
        }

        public void RemoveFromNavigationStack<T>(bool removeFirstOccurenceOnly = true) where T : IViewModel
        {
            Type pageType = typeof(T).IsAssignableTo<ITabbedViewModel>()
                ? typeof(AWTabbedPage)
                : PageLocator.ResolvePageType(typeof(T));

            var navigationStack = Navigation.NavigationStack.Reverse();
            foreach (var page in navigationStack)
            {
                if (page.GetType() == pageType)
                {
                    Navigation.RemovePage(page);
                    if (removeFirstOccurenceOnly)
                        break;
                }
            }
        }

        public IReadOnlyList<IViewModel> GetNavigationStack()
        {
            return Navigation.NavigationStack.Select(page => page.BindingContext as IViewModel).ToList();
        }

        public void NotifyViewModel<T>(object sender, ViewModelNotificationType notificationType, object args = null) where T : IViewModel
        {
            var navigationStack = GetNavigationStack().Reverse();
            foreach (var viewModel in navigationStack)
            {
                if (viewModel.GetType() == typeof(T))
                {
                    //viewModel.OnNavigationServiceNotification(sender, notificationType, args);
                    break;
                }
                else if (viewModel.GetType().IsAssignableTo<ITabbedViewModel>())
                {
                    var tabbedViewModel = (ITabbedViewModel)viewModel;
                    if (tabbedViewModel.ChildViewModels.Any(x => x.Value.GetType() == typeof(T)))
                    {
                        //tabbedViewModel.ChildViewModels.First(x => x.Value.GetType() == typeof(T)).Value.
                        //    OnNavigationServiceNotification(sender, notificationType, args);
                        break;
                    }
                }
            }
        }

        //public async Task<AddEditResult<TResult>> NavigateToAddEditModel<TViewModel, TResult>(TResult initial = null) where TViewModel : AddEditViewModel<TResult> where TResult : class, IDTO
        //{
        //    var page = ResolvePageFor<TViewModel>(initial);

        //    var viewModel = (TViewModel)page.BindingContext;

        //    await Navigation.PushAsync(page);

        //    return await viewModel.ResultTask.Task;
        //}

        //public async Task<TResult> NavigateToSingleSelection<TViewModel, TResult>(SingleSelectionOptions<TResult> options = null) where TViewModel : SingleSelectionViewModel<TResult> where TResult : IDTO
        //{
        //    var page = ResolvePageFor<TViewModel>(options);

        //    var viewModel = (TViewModel)page.BindingContext;

        //    await Navigation.PushAsync(page);

        //    return await viewModel.SingleSelectionTask.Task;
        //}

        //public async Task<MultipleSelectionResult<TResult>> NavigateToMultiSelection<TViewModel, TResult>(MultipleSelectionOptions<TResult> options = null) where TViewModel : IMultiSelectionViewModel<TResult> where TResult : IDTO
        //{
        //    var page = ResolvePageFor<TViewModel>(options);

        //    var viewModel = (TViewModel)page.BindingContext;

        //    await Navigation.PushAsync(page);

        //    return await viewModel.MultiSelectionTask.Task;
        //}

        public bool IsRootPage
        {
            get { return Navigation.NavigationStack.Count == 1; }
        }

        public IViewModel CurrentViewModel
        {
            get { return CurrentPage?.BindingContext as IViewModel; }
        }

        public Page CurrentPage
        {
            get { return Navigation?.NavigationStack?.LastOrDefault(); }
        }

        public void OpenDrawerMenu()
        {
            PresentDrawerMenu(true);
        }

        public void CloseDrawerMenu()
        {
            PresentDrawerMenu(false);
        }

        public void ToggleDrawerMenu()
        {
            var masterDetailPage = App.MainPage as MasterDetailPage;

            if (masterDetailPage != null)
                masterDetailPage.IsPresented = !masterDetailPage.IsPresented;
        }

        private void PresentDrawerMenu(bool isPresented)
        {
            var masterDetailPage = App.MainPage as MasterDetailPage;

            if (masterDetailPage != null)
                masterDetailPage.IsPresented = isPresented;
        }


    }
}
