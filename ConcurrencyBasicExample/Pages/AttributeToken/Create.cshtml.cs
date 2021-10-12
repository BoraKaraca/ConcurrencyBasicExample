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

namespace WebUI.Pages.AttributeToken
{
    public class CreateModel : PageModel
    {
        private readonly ConcurrencyCheckAttributeTokenService _concurrencyCheckAttributeTokenService;
        public CreateModel(ConcurrencyCheckAttributeTokenService concurrencyCheckAttributeTokenService)
        {
            _concurrencyCheckAttributeTokenService = concurrencyCheckAttributeTokenService;
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

            await _concurrencyCheckAttributeTokenService.CreateItemAsync(requestViewModel);

            return RedirectToPage("/AttributeToken/List");
        }
    }
}
