using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrencyBasicExample.Application.ViewModel
{
    public class ConcurrencySampleRequestViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public int Age { get; set; }
    }
}
