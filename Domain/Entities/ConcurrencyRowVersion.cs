using System.ComponentModel.DataAnnotations;

namespace ConcurrencyBasicExample.Domain.Entities
{
    public class ConcurrencyRowVersion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

    }
}
