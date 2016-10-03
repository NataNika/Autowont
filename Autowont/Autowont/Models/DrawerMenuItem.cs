using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;
using System.Windows.Input;

namespace Autowont.Models
{
    [ImplementPropertyChanged]
    public class DrawerMenuItem
    {
        public DrawerMenuItem()
        {
            IsEnabled = true;
            IsVisible = true;
        }

        private string _displayName;
        public string DisplayName
        {
            get { return _displayName; }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _displayName = value;
                    return;
                }

                _displayName = value;
            }
        }

        public string Icon { get; set; }

        public ICommand Command { get; set; }

        public bool IsEnabled { get; set; }

        public bool IsVisible { get; set; }

    }
}
