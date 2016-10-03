using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autowont.ViewModels;
using Autowont.Services;
using Autowont.Models;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace Autowont.ViewModels
{
    public class DrawerMenuViewModel : ViewModel
    {
        
        public DrawerMenuViewModel( IApp app, IDialogsService dialogsService,
            INavigationService navigationService)
            : base(app, dialogsService, navigationService)
        {
            
           
            Title = "☰";
            MenuItems = new List<DrawerMenuItem>();
            MenuItems.Add(new DrawerMenuItem()
            {
                DisplayName = "Поиск",
                Icon = "searcheIcon",
                Command = SearchItem

            });
            MenuItems.Add(new DrawerMenuItem()
            {
                DisplayName = "Сообщения",
                Icon = "messageIcon",
                Command = MessageItem
            });
            MenuItems.Add(new DrawerMenuItem()
            {
                DisplayName = "История",
                Icon = "historyIcon",
                Command = HistoryItem

            });
            MenuItems.Add(new DrawerMenuItem()
            {
                DisplayName = "Закладки",
                Icon = "favoriteIcon",
                Command = FavoriteItem
            });
            MenuItems.Add(new DrawerMenuItem()
            {
                DisplayName = "Настройки",
                Icon = "settingsIcon",
                Command = SettingsItem
            });
        }

        public string UserAvatarUrl { get; set; }

        public string UserName { get; set; }

        public override void OnAppearing()
        {
            base.OnAppearing();

           
        }

        
        public List<DrawerMenuItem> MenuItems { get; set; }

        public DrawerMenuItem SelectedMenuItem
        {
            get { return null; }
            set
            {
                if (value != null && value.IsEnabled && value.Command != null)
                {
                    Navigation.CloseDrawerMenu();
                    value.Command.Execute(null);
                }
            }
        }

        public ICommand SearchItem
        {
            get
            {
                return new RelayCommandAsync(async () =>
                {
                    this.Navigation.CloseDrawerMenu();
                    await Navigation.NavigateToAsync<SearchViewModel>();
                }, this);
            }
        }

        public ICommand MessageItem
        {
            get
            {
                return new RelayCommandAsync(async () =>
                {
                    this.Navigation.CloseDrawerMenu();
                    await Navigation.NavigateToAsync<MessagesViewModel>();
                }, this);
            }
        }

        public ICommand HistoryItem
        {
            get
            {
                return new RelayCommandAsync(async () =>
                {
                    this.Navigation.CloseDrawerMenu();
                    await Navigation.NavigateToAsync<HistoryViewModel>();
                }, this);
            }
        }

        public ICommand FavoriteItem
        {
            get
            {
                return new RelayCommandAsync(async () =>
                {
                    this.Navigation.CloseDrawerMenu();
                    await Navigation.NavigateToAsync<FavoriteViewModel>();
                }, this);
            }
        }

        public ICommand SettingsItem
        {
            get
            {
                return new RelayCommandAsync(async () =>
                {
                    this.Navigation.CloseDrawerMenu();
                    await Navigation.NavigateToAsync<SettingsViewModel>();
                }, this);
            }
        }

    }
}