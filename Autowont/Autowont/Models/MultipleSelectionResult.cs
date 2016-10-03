using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autowont.Enums;

namespace Autowont.Models
{
    public class MultipleSelectionResult<T> 
    {
        public MultipleSelectionResult()
        {
            SelectedItems = new List<T>();
            DeselectedItems = new List<T>();
            Status = MultipleSelectionResultStatus.Cancelled;
        }


        public IEnumerable<T> SelectedItems { get; set; }

        public IEnumerable<T> DeselectedItems { get; set; }

        public MultipleSelectionResultStatus Status { get; set; }
    }
}
