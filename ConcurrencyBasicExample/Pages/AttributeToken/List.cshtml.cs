using ConcurrencyBasicExample.Application.Services;
using ConcurrencyBasicExample.Application.ViewModel;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace WebUI.Pages.AttributeToken
{
    public class ListModel : PageModel
    {
        private readonly ConcurrencyCheckAttributeTokenService _concurrencyCheckAttributeTokenService;
        public ListModel(ConcurrencyCheckAttributeTokenService concurrencyCheckAttributeTokenService)
        {
            _concurrencyCheckAttributeTokenService = concurrencyCheckAttributeTokenService;
        }
 

        public ConcurrencySampleViewModel SampleViewModel { get;set; }

        public async Task OnGetAsync()
        {
            SampleViewModel = await _concurrencyCheckAttributeTokenService.GetListAsync();
        }
    }
}
