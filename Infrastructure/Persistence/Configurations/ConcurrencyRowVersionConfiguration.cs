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
    public class ConcurrencyRowVersionConfiguration : IEntityTypeConfiguration<ConcurrencyRowVersion>
    {

        public void Configure(EntityTypeBuilder<ConcurrencyRowVersion> builder)
        {
            //builder.Property(_ => _.RowVersion).IsRowVersion(); //EntityModel içinde [Timestamp] tanımlamadan bu şekildede set edebiliyoruz.     
        }
    }
}
