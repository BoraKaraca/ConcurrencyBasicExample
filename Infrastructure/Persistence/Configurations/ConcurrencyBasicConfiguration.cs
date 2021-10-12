using ConcurrencyBasicExample.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrencyBasicExample.Infrastructure.Persistence.Configurations
{
    public class ConcurrencyBasicConfiguration : IEntityTypeConfiguration<ConcurrencyBasic>
    {
        public void Configure(EntityTypeBuilder<ConcurrencyBasic> builder)
        {
 
        }
    }
}
