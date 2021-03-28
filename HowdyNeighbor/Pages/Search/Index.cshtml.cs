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
    public class IndexModel : PageModel
    {
        private readonly HowdyNeighbor.Data.ApplicationDbContext _context;

        public IndexModel(HowdyNeighbor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<SearchList> SearchList { get;set; }

        public async Task OnGetAsync()
        {
            SearchList = await _context.SearchList.ToListAsync();
        }
    }
}
