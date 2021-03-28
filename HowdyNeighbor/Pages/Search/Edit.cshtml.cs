using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HowdyNeighbor.Data;
using HowdyNeighbor.Models;

namespace HowdyNeighbor.Pages.Search
{
    public class EditModel : PageModel
    {
        private readonly HowdyNeighbor.Data.ApplicationDbContext _context;

        public EditModel(HowdyNeighbor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SearchList SearchList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SearchList = await _context.SearchList.FirstOrDefaultAsync(m => m.ID == id);

            if (SearchList == null)
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

            _context.Attach(SearchList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SearchListExists(SearchList.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SearchListExists(int id)
        {
            return _context.SearchList.Any(e => e.ID == id);
        }
    }
}
