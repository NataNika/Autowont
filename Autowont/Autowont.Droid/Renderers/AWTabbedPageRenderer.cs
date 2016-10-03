using System.Collections.Generic;
using Android.App;
using Android.Support.Design.Widget;
using Android.Views;
using Autowont.Droid.Renderers;
using Autowont.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Support.V7.Widget;
using Autowont.Pages;
using Xamarin.Forms.Platform.Android.AppCompat;
using Android.Widget;
using Android.Util;

[assembly: ExportRenderer(typeof(AWTabbedPage), typeof(AWTabbedPageRenderer))]

namespace Autowont.Droid.Renderers
{
    public class AWTabbedPageRenderer : TabbedPageRenderer
    {
        private readonly Dictionary<ViewModel, AWTab> tabs;

        public AWTabbedPageRenderer()
        {
            tabs = new Dictionary<ViewModel, AWTab>();
        }

        protected override void OnWindowVisibilityChanged(ViewStates visibility)
        {
            base.OnWindowVisibilityChanged(visibility);

            if (visibility == ViewStates.Visible)
            {
                TabLayout tabLayout = (TabLayout)this.GetChildAt(1);
                var tabbedPage = (AWTabbedPage)Element;
                int tabIndex = 0;
                foreach (var page in tabbedPage.Children)
                {
                    var viewModel = page.BindingContext as ViewModel;
                    if (viewModel != null)
                    {
                        if (!tabs.ContainsKey(viewModel))
                        {
                            AWTab awTab = CreateClubrTab(tabLayout.GetTabAt(tabIndex), page.Title, viewModel.Badge);
                            tabs.Add(viewModel, awTab);
                        }

                        viewModel.BadgeChange += OnViewModelBadgeChange;
                    }

                    tabIndex++;
                }
            }
        }

        private void OnViewModelBadgeChange(ViewModel viewModel)
        {
            AWTab awTab;
            if (tabs.TryGetValue(viewModel, out awTab))
            {
                string tabTitle = string.IsNullOrWhiteSpace(viewModel.Badge)
                    ? awTab.OriginalTitle
                    : $"{awTab.OriginalTitle}({viewModel.Badge})";
                awTab.TitleView?.SetText(tabTitle, TextView.BufferType.Spannable);
            }
        }

        private AWTab CreateClubrTab(TabLayout.Tab tab, string title, string badge)
        {
            string tabTitle = string.IsNullOrWhiteSpace(badge)
                                ? title
                                : $"{title}({badge})";
            TextView textView = GetTabTitleView(tabTitle, title);
            tab?.SetCustomView(textView);

            var awTab = new AWTab(textView, title);
            return awTab;
        }

        /// <summary>
        /// Gets customized TextView for Tab Title
        /// </summary>
        /// <param name="contentDescription">ContentDescription of Tab</param>
        /// <param name="tabTitle">Text that shows on Tab title</param>
        /// <returns>Customized TextView</returns>
        private TextView GetTabTitleView(string tabTitle, string contentDescription)
        {
            TextView textView = new TextView(Context);
            textView.SetText(tabTitle, TextView.BufferType.Spannable);
            textView.ContentDescription = contentDescription;
            textView.Gravity = GravityFlags.CenterVertical | GravityFlags.CenterHorizontal;
            textView.SetAllCaps(true);
            textView.SetTextSize(ComplexUnitType.Dip, 8);



            return textView;
        }

        class AWTab
        {
            public TextView TitleView { get; }
            public string OriginalTitle { get; }

            public AWTab(TextView titleView, string originalTitle)
            {
                TitleView = titleView;
                OriginalTitle = originalTitle;
            }
        }
    }
}