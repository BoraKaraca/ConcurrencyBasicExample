using ConcurrencyBasicExample.Application.Common.Interfaces;
using ConcurrencyBasicExample.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrencyBasicExample.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<ConcurrencyBasic> ConcurrencyBasics { get; set; }
        public DbSet<ConcurrencyCheckAttributeToken> ConcurrencyCheckAttributeTokens { get; set; }
        public DbSet<ConcurrencyRowVersion> ConcurrencyRowVersions { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        IsConcurrencyTokenCheck(entries);
                        break;
                }
            }

        }

        private void IsConcurrencyTokenCheck(IEnumerable<EntityEntry> entries)
        {
            var modifiedEntites = entries.Where(x => x.State == EntityState.Modified && x.Entity.GetType().Name!= "ConcurrencyCheckAttributeToken").ToList();//AttributeTokenı dahil etmeme sebebi maplenmeyen kayıtı yollayamadığımız için orjinal değeri değişiyor gibi algılıyor.
            foreach (var change in modifiedEntites)
            {
                var name = change.Entity.GetType().Name;
                var concurrenyTokenList = change.OriginalValues.Properties.Where(p => p.IsConcurrencyToken == true);
                foreach (var token in concurrenyTokenList)
                {
                    change.OriginalValues[token.Name] = change.CurrentValues[token.Name];//Sayfada ilk açılan değerden farklı değer varsa kirli kayıt olduğundan günceleme işlemine izin verilmiyor.
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());//Configuration Klasöründe İlgili Tabloların Propertileri set edebiliriz.
            base.OnModelCreating(modelBuilder);
        }
    }
}
