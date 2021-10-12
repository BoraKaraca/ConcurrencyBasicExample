using ConcurrencyBasicExample.Application.Common.Interfaces;
using ConcurrencyBasicExample.Application.ViewModel;
using ConcurrencyBasicExample.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ConcurrencyBasicExample.Application.Services
{
    public class ConcurrencyRowVersionService
    {
        private readonly IApplicationDbContext _context;
        public ConcurrencyRowVersionService(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ConcurrencySampleViewModel> GetListAsync()
        {
            var entity = await _context.ConcurrencyRowVersions.ToListAsync();
            var sampleItems = entity.Select(x => CreateViewModel(x)).ToList();

            return new ConcurrencySampleViewModel() { SampleItems = sampleItems };
        }

        private SampleItem CreateViewModel(ConcurrencyRowVersion x)
        {
            return new SampleItem
            {
                Id = x.Id,
                Name = x.Name,
                Lastname = x.Lastname,
                Age = x.Age,
                RowVersion = x.RowVersion

            };
        }

        public async Task CreateItemAsync(ConcurrencySampleRequestViewModel request)
        {
            _context.ConcurrencyRowVersions.Add(new ConcurrencyRowVersion()
            {
                Name = request.Name,
                Lastname = request.Lastname,
                Age = request.Age
            });

            await _context.SaveChangesAsync();
        }

        public async Task<SampleItem> GetItemByIdAsync(int id)
        {
            var entity = await _context.ConcurrencyRowVersions.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (entity == null)
                return null;

            return new SampleItem()
            {
                Id = entity.Id,
                Name = entity.Name,
                Lastname = entity.Lastname,
                Age = entity.Age,
                RowVersion = entity.RowVersion
            };
        }

        public async Task UpdateItemAsync(SampleItem sampleItem)
        {

            var entity = await _context.ConcurrencyRowVersions.FindAsync(sampleItem.Id);

            entity.Name = sampleItem.Name;
            entity.Lastname = sampleItem.Lastname;
            entity.Age = sampleItem.Age;
            entity.RowVersion = sampleItem.RowVersion;//İlk rowVersion değerini yollayarak concurrency kontrolü sağlanıyor.

            await _context.SaveChangesAsync();
        }
    }
}
