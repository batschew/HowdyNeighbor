using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HowdyNeighbor.Data;
using HowdyNeighbor.Models;

namespace HowdyNeighbor.Pages.Move
{
    public class DetailsModel : PageModel
    {
        private readonly HowdyNeighbor.Data.ApplicationDbContext _context;

        public DetailsModel(HowdyNeighbor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public ChecklistTask ChecklistTask { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ChecklistTask = await _context.ChecklistTask.FirstOrDefaultAsync(m => m.ID == id);

            if (ChecklistTask == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
