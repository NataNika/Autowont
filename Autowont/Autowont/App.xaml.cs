using System.Reflection;
using Autofac;
using Autowont.Services;
using Autowont.ViewModels;
using PropertyChanged;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;

#if !DEBUG || TRUE
[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
#endif
namespace Autowont
{
    [ImplementPropertyChanged]
    [XamlCompilation(XamlCompilationOptions.Skip)]
    public partial class App : Application, IApp
    {
        public IContainer Container { get; private set; }
        public DatabaseService database { get; private set; }
        public bool IsVisible { get; set; }
        public string OpenUrl { get; set; }


        public App()
        {
            InitializeComponent();
            SetupDependencyInjection();
            SetStartPage();
            if (database == null)
            {
                database = new DatabaseService();
            }
        }

        private void SetupDependencyInjection()
        {
            if (Container != null)
                return;
            // Register all ViewModels, Pages, Services and any Xamarin Dependecies
            var builder = new ContainerBuilder();
            builder.Register<IApp>(c => Application.Current as App).SingleInstance();
            builder.RegisterMvvmComponents(typeof(App).GetTypeInfo().Assembly);
            //builder.RegisterXamDependency<IPlatformSpecific>();
            //builder.RegisterXamDependency<IDeviceInfoService>();
            builder.RegisterType<NavigationService>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<DialogsService>().AsImplementedInterfaces().SingleInstance();


            Container = builder.Build();
        }

        public void SetStartPage()
        {
            var navigationService = Container.Resolve<INavigationService>();
            navigationService.SetMainViewModel<LoginViewModel>();
        }

        protected override void OnStart()
        {
            IsVisible = true;
            base.OnStart();
        }
        protected override void OnSleep()
        {
            IsVisible = false;
            base.OnSleep();
        }
        protected override void OnResume()
        {
            IsVisible = true;
            base.OnResume();
        }
    }
}
