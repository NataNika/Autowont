using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Windows.Input;

namespace Autowont.Views
{
    public class BindablePicker : Picker
    {
        public BindablePicker()
        {
            this.SelectedIndexChanged += OnSelectedIndexChanged;
        }

        public static BindableProperty ItemsSourceProperty = BindableProperty.Create("ItemsSource", typeof(IEnumerable), typeof(BindablePicker), default(IEnumerable), default(BindingMode), null, BindablePicker.OnItemsSourceChanged);

        public static BindableProperty SelectedItemProperty = BindableProperty.Create("SelectedItem", typeof(object), typeof(BindablePicker), null, default(BindingMode), null, BindablePicker.OnSelectedItemChanged);

        public static readonly BindableProperty CommandProperty = BindableProperty.Create("Command", typeof(ICommand), typeof(BindablePicker), null);

        IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        object SelectedItem
        {
            get { return (object)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        public ICommand Command
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

        private static void OnItemsSourceChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var picker = bindable as BindablePicker;
            var newItems = newvalue as IEnumerable;

            if (picker == null)
                throw new Exception("InvalidBindable New Property value: " + bindable != null ? bindable.ToString() : "null");

            if (newItems == null)
                throw new Exception("InvalidBindable New Property value: " + newvalue != null ? newvalue.ToString() : "null");

            picker.Items.Clear();

            if (newvalue != null)
                foreach (var item in newItems)
                    picker.Items.Add(item.ToString());
        }

        private void OnSelectedIndexChanged(object sender, EventArgs eventArgs)
        {
            if (ItemsSource == null)
                return;
            
            if (SelectedIndex < 0 || SelectedIndex > Items.Count - 1)
                SelectedItem = null;

            var enumerator = ItemsSource.GetEnumerator();
            enumerator.Reset();

            for (int i = 0; i < Items.Count; i++) 
            {
                enumerator.MoveNext();
                if (i == SelectedIndex)
                {
                    SelectedItem = enumerator.Current;
                    Command.Execute(new object());
                    break;
                }
            }
               
        }

        private static void OnSelectedItemChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var picker = bindable as BindablePicker;
            if (newvalue != null)
                picker.SelectedIndex = picker.Items.IndexOf(newvalue.ToString());
        }
    }
}
