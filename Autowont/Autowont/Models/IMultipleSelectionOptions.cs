using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autowont.Models
{
    public interface IMultipleSelectionOptions<T>
    {
        IEnumerable<T> InitialSelection { get; set; }
        IEnumerable<T> ItemsToExclude { get; set; }
    }
}
