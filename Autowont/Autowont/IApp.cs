using Autofac;
using Autowont.Services;
using Xamarin.Forms;

namespace Autowont
{
    public interface IApp
    {
        DatabaseService database { get; }
        Page MainPage { get; set; }

        IContainer Container { get; }

        string OpenUrl { get; set; }

        void SetStartPage();
    }
}
