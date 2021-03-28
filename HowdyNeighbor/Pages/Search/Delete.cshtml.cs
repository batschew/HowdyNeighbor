using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HowdyNeighbor.Data;
using HowdyNeighbor.Models;

namespace HowdyNeighbor.Pages.Search
{
    public class DeleteModel : PageModel
    {
        private readonly HowdyNeighbor.Data.ApplicationDbContext _context;

        public DeleteModel(HowdyNeighbor.Data.ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SearchList = await _context.SearchList.FindAsync(id);

            if (SearchList != null)
            {
                _context.SearchList.Remove(SearchList);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
