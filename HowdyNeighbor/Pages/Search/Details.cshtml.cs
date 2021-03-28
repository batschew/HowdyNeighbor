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
    public class DetailsModel : PageModel
    {
        private readonly HowdyNeighbor.Data.ApplicationDbContext _context;

        public DetailsModel(HowdyNeighbor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
