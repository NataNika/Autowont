using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Autowont.Pages
{ 
   
    public interface IAWPage
    {
        void SetBinding<TSource>(BindableProperty targetProperty,
                System.Linq.Expressions.Expression<Func<TSource, object>> sourceProperty,
                BindingMode mode = 0,
                IValueConverter converter = null,
                string stringFormat = null);

        IList<ToolbarItem> ToolbarItems { get; }

        string Title { get; set; }

        FileImageSource Icon { get; set; }

        object BindingContext { get; set; }

        event EventHandler Appearing;

        event EventHandler Disappearing;

        event PageClosedEventHandler PageClosing;

        void OnPageClosing();
    }
}
