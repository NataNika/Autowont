using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Autowont.ViewModels;
using Xamarin.Forms;

namespace Autowont.Pages
{
    public class AWTabbedPage : TabbedPage, IAWPage
    {
        public void SetBinding<TSource>(BindableProperty targetProperty, Expression<Func<TSource, object>> sourceProperty, BindingMode mode = BindingMode.Default,
            IValueConverter converter = null, string stringFormat = null)
        {
            (this as BindableObject).SetBinding(targetProperty, sourceProperty, mode,
                converter, stringFormat);
        }

        public event PageClosedEventHandler PageClosing;

        public void OnPageClosing()
        {
            if (PageClosing != null)
                PageClosing.Invoke(this, new EventArgs());
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            var viewModel = BindingContext as ITabbedViewModel;

            if (viewModel != null && viewModel.ToolbarItems != null && viewModel.ToolbarItems.Count > 0)
            {

                //viewModel.ToolbarItems.CollectionChanged += ViewModel_ToolbarItems_CollectionChanged;

                foreach (var toolBarItem in viewModel.ToolbarItems)
                {
                    if (!(this.ToolbarItems.Contains(toolBarItem)))
                    {
                        this.ToolbarItems.Add(toolBarItem);
                    }
                }
            }

        }

        void ViewModel_ToolbarItems_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            foreach (ToolbarItem toolBarItem in e.NewItems)
            {
                if (!(this.ToolbarItems.Contains(toolBarItem)))
                {
                    this.ToolbarItems.Add(toolBarItem);
                }
            }

            if (e.Action == NotifyCollectionChangedAction.Remove || e.Action == NotifyCollectionChangedAction.Replace)
            {
                foreach (ToolbarItem toolBarItem in e.OldItems)
                {
                    if (!(this.ToolbarItems.Contains(toolBarItem)))
                    {
                        this.ToolbarItems.Add(toolBarItem);
                    }
                }
            }
        }

        protected override bool OnBackButtonPressed()
        {
            OnPageClosing();
            return base.OnBackButtonPressed();
        }
    }
}
