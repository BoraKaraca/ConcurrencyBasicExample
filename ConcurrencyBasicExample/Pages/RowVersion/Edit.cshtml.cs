using ConcurrencyBasicExample.Application.Services;
using ConcurrencyBasicExample.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace WebUI.Pages.RowVersion
{
    public class EditModel : PageModel
    {
        private readonly ConcurrencyRowVersionService _concurrencyRowVersionService;
        public EditModel(ConcurrencyRowVersionService concurrencyRowVersionService)
        {
            _concurrencyRowVersionService = concurrencyRowVersionService;
        }

        [BindProperty]
        public SampleItem SampleItem { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SampleItem = await _concurrencyRowVersionService.GetItemByIdAsync(id ?? 0);

            if (SampleItem == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _concurrencyRowVersionService.UpdateItemAsync(SampleItem);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                TempData["errorMessage"] = $"Data güncellenemedi. {ex.Message}";
                return RedirectToPage("/RowVersion/List");
            }


            return RedirectToPage("/RowVersion/List");
        }


    }
}
