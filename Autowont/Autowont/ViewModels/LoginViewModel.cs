using System.Windows.Input;
using Autowont.Services;
using Xamarin.Forms;

namespace Autowont.ViewModels
{
    public class LoginViewModel : ViewModel
    {
        
        public LoginViewModel(IApp app, IDialogsService dialogsService, INavigationService navigationService) : base(app, dialogsService, navigationService)
        {
            
        }

        public ICommand LoginCommand
        {
            get
            {

                return new Command(() => Navigation.SetMainViewModel<MainViewModel>());
                //return new RelayCommandWithArgsAsync<object>(async args =>
                //{

                //    await Navigation.NavigateToModalAsync<MainViewModel>(args);
                //}, this);
            }
        }
    }
}
