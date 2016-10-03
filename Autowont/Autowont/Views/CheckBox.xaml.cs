using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Autowont.Views
{
    public partial class CheckBox : ContentView
    {
        public static readonly BindableProperty CheckedProperty = BindableProperty.Create("Checked", typeof(bool), typeof(CheckBox), false, BindingMode.TwoWay, null, OnCheckedPropertyChanged);
        //public static readonly BindableProperty IsCheckedProperty =
        //    BindableProperty.Create<CheckBox, bool>(v => v.IsChecked, false,
        //        BindingMode.TwoWay, CheckBox.OnIsCheckedChanged);
        //public static readonly BindableProperty CommandProperty = BindableProperty.Create("CheckCommand", typeof(ICommand), typeof(CheckBox), null, BindingMode.TwoWay);
        public static readonly BindableProperty CommandProperty =BindableProperty.Create<CheckBox, ICommand>(x => x.CheckCommand, null);

        public bool Checked
        {
            get
            {
                return this.GetValue<bool>(CheckedProperty);
            }

            set
            {
                if (this.Checked != value)
                {
                    this.SetValue(CheckedProperty, value);
                    //this.CheckedChanged.Invoke(this, value);
                }
            }
        }
        //public bool IsChecked
        //{
        //    get
        //    {
        //        return (bool)GetValue(IsCheckedProperty);
        //    }
        //    set
        //    {
        //        SetValue(IsCheckedProperty, value);
        //    }
        //}

        public ICommand CheckCommand
        {
            get
            {
                return GetValue(CommandProperty) as ICommand;
            }
            set
            {
                SetValue(CommandProperty, value);
            }
        }
        private static void OnCheckedPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var checkBox = (CheckBox)bindable;
            checkBox.Checked = (bool)newvalue;
            var v = (CheckBox)bindable;
            v.Box.Source = (bool)newvalue ? "ic_check" : "";
            
        }
        //public void OnIsCheckedChanged(BindableObject bindable, bool oldvalue, bool newvalue)
        //{

        //    var v = (CheckBox)bindable;
        //    v.Box.Source = newvalue ? "ic_check" : "";
        //    CheckCommand.Execute(new object());
        //    //Command.Execute(null);
        //}



        public CheckBox()
        {
            InitializeComponent();
        }

        void OnTapGestureRecognizerTapped(object sender, EventArgs args)
        {
            Checked = !Checked;
            if (CheckCommand != null && CheckCommand.CanExecute(null))
            {
                CheckCommand.Execute(null);
            }

        }
        private T GetValue<T>(BindableProperty property)
        {
            return (T)GetValue(property);
        }
    }
}
