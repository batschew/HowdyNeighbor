using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HowdyNeighbor.Data;
using HowdyNeighbor.Models;

namespace HowdyNeighbor.Pages.Search
{
    public class CreateModel : PageModel
    {
        private readonly HowdyNeighbor.Data.ApplicationDbContext _context;

        public CreateModel(HowdyNeighbor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public SearchList SearchList { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.SearchList.Add(SearchList);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
