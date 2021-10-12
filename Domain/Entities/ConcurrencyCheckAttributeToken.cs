using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrencyBasicExample.Domain.Entities
{
    public class ConcurrencyCheckAttributeToken
    {
        public int Id { get; set; }
        [ConcurrencyCheck]
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
    }
}
