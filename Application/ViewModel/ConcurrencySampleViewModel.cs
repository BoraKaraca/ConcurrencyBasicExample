using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrencyBasicExample.Application.ViewModel
{
    public class ConcurrencySampleViewModel
    {
        public IList<SampleItem> SampleItems { get; set; }
    }
    public class SampleItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }

        public string OriginalNameValue { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
