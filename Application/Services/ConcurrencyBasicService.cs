using ConcurrencyBasicExample.Application.Common.Interfaces;
using ConcurrencyBasicExample.Application.ViewModel;
using ConcurrencyBasicExample.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ConcurrencyBasicExample.Application.Services
{
    public class ConcurrencyBasicService
    {
        private readonly IApplicationDbContext _context;
        public ConcurrencyBasicService(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ConcurrencySampleViewModel> GetListAsync()
        {
            var entity = await _context.ConcurrencyBasics.ToListAsync();
            var sampleItems = entity.Select(x => CreateViewModel(x)).ToList();

            return new ConcurrencySampleViewModel() { SampleItems = sampleItems };
        }

        private SampleItem CreateViewModel(ConcurrencyBasic x)
        {
            return new SampleItem
            {
                Id = x.Id,
                Name = x.Name,
                Lastname = x.Lastname,
                Age = x.Age
            };
        }

        public async Task CreateItemAsync(ConcurrencySampleRequestViewModel request)
        {
            _context.ConcurrencyBasics.Add(new ConcurrencyBasic()
            {
                Name = request.Name,
                Lastname = request.Lastname,
                Age = request.Age
            });

            await _context.SaveChangesAsync();
        }

        public async Task<SampleItem> GetItemByIdAsync(int id)
        {
            var entity = await _context.ConcurrencyBasics.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (entity == null)
                return null;

            return new SampleItem()
            {
                Id = entity.Id,
                Name = entity.Name,
                Lastname = entity.Lastname,
                Age = entity.Age
            };
        }

        public async Task UpdateItemAsync(SampleItem sampleItem)
        {
            var entity = await _context.ConcurrencyBasics.FindAsync(sampleItem.Id);
            if (entity == null)
                throw new ArgumentNullException(nameof(ConcurrencyBasic));

            entity.Name = sampleItem.Name;
            entity.Lastname = sampleItem.Lastname;
            entity.Age = sampleItem.Age;

            await _context.SaveChangesAsync();
        }

    }

}
