using ConcurrencyBasicExample.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrencyBasicExample.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<ConcurrencyBasic> ConcurrencyBasics { get; set; }
        DbSet<ConcurrencyCheckAttributeToken> ConcurrencyCheckAttributeTokens { get; set; }
        DbSet<ConcurrencyRowVersion> ConcurrencyRowVersions { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }
}
