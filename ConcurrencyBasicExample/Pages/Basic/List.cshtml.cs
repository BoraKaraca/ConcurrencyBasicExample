using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ConcurrencyBasicExample.Domain.Entities;
using ConcurrencyBasicExample.Infrastructure.Persistence;
using ConcurrencyBasicExample.Application.Services;
using ConcurrencyBasicExample.Application.ViewModel;

namespace WebUI.Pages.Basic
{
    public class ListModel : PageModel
    {
        private readonly ConcurrencyBasicService _concurrencyBasicService;
        public ListModel(ConcurrencyBasicService concurrencyBasicService)
        {
            _concurrencyBasicService = concurrencyBasicService;
        }
 

        public ConcurrencySampleViewModel SampleViewModel { get;set; }

        public async Task OnGetAsync()
        {
            SampleViewModel = await _concurrencyBasicService.GetListAsync();
        }
    }
}
