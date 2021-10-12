using ConcurrencyBasicExample.Application.Services;
using ConcurrencyBasicExample.Application.ViewModel;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace WebUI.Pages.RowVersion
{
    public class ListModel : PageModel
    {
        private readonly ConcurrencyRowVersionService _concurrencyRowVersionService;
        public ListModel(ConcurrencyRowVersionService concurrencyRowVersionService)
        {
            _concurrencyRowVersionService = concurrencyRowVersionService;
        }
 

        public ConcurrencySampleViewModel SampleViewModel { get;set; }

        public async Task OnGetAsync()
        {
            SampleViewModel = await _concurrencyRowVersionService.GetListAsync();
        }
    }
}
