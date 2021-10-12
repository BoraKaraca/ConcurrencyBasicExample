using ConcurrencyBasicExample.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace ConcurrencyBasicExample.Infrastructure.Persistence.Configurations
{
    class ConcurrencyCheckAttributeTokenConfiguration : IEntityTypeConfiguration<ConcurrencyCheckAttributeToken>
    {
        public void Configure(EntityTypeBuilder<ConcurrencyCheckAttributeToken> builder)
        {
            //builder.Property(t => t.Name).IsConcurrencyToken(); //EntityModel içinde [ConcurrencyCheck] tanımlamadan bu şekildede set edebiliyoruz.
        }
    }
}
