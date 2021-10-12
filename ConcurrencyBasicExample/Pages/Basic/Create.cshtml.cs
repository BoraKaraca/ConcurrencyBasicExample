using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ConcurrencyBasicExample.Domain.Entities;
using ConcurrencyBasicExample.Infrastructure.Persistence;
using ConcurrencyBasicExample.Application.ViewModel;
using ConcurrencyBasicExample.Application.Services;

namespace WebUI.Pages.Basic
{
    public class CreateModel : PageModel
    {
        private readonly ConcurrencyBasicService _concurrencyBasicService;
        public CreateModel(ConcurrencyBasicService concurrencyBasicService)
        {
            _concurrencyBasicService = concurrencyBasicService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ConcurrencySampleRequestViewModel requestViewModel { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _concurrencyBasicService.CreateItemAsync(requestViewModel);

            return RedirectToPage("/Basic/List");
        }
    }
}
