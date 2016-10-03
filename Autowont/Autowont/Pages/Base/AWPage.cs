using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Autowont.ViewModels;
using Xamarin.Forms;

namespace Autowont.Pages
{
    public delegate void PageClosedEventHandler(object sender, EventArgs e);

    public class AWPage : ContentPage, IAWPage
    {
        public AWPage()
        {
            BackgroundColor = Color.FromHex("FFFF93");
        }

        public void SetBinding<TSource>(BindableProperty targetProperty, Expression<Func<TSource, object>> sourceProperty, BindingMode mode = BindingMode.Default,
                                        IValueConverter converter = null, string stringFormat = null)
        {
            (this as BindableObject).SetBinding(targetProperty, sourceProperty, mode,
                converter, stringFormat);
        }


        public event PageClosedEventHandler PageClosing;

        public void OnPageClosing()
        {
            PageClosing?.Invoke(this, new EventArgs());
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            var viewModel = BindingContext as IViewModel;

            if (viewModel?.ToolbarItems == null)
                return;

            viewModel.ToolbarItems.CollectionChanged += ViewModel_ToolbarItems_CollectionChanged;

            foreach (var toolBarItem in viewModel.ToolbarItems)
                if (ToolbarItems.All(x => x.Text != toolBarItem.Text))
                    ToolbarItems.Add(toolBarItem);

        }

        private void ViewModel_ToolbarItems_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            ToolbarItems.Clear();

            var vmToolbar = sender as ObservableCollection<ToolbarItem>;

            if (vmToolbar == null)
                return;

            foreach (var item in vmToolbar)
                if (ToolbarItems.All(x => x.Text != item.Text))
                    ToolbarItems.Add(item);

        }
    }
}
