using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HowdyNeighbor.Authorization;
using HowdyNeighbor.Data;
using HowdyNeighbor.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace HowdyNeighbor.Pages
{
    public class SchoolDistrictModel : BasePageModel
    {
        public SchoolDistrictModel(ApplicationDbContext context, IAuthorizationService authorizationService, UserManager<IdentityUser> userManager) : base(context, authorizationService, userManager)
        {
        }

        [BindProperty]
        public SearchList SearchList { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            SearchList = await Context.SearchList.FirstOrDefaultAsync(list => list.ID == id);
            if (SearchList == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(User, SearchList, Operations.Update);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var searchList = await Context.SearchList.AsNoTracking().FirstOrDefaultAsync(list => list.ID == id);

            if (searchList == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(User, searchList, Operations.Update);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            SearchList.OwnerID = searchList.OwnerID;
            Context.Attach(SearchList).Property(list => list.SchoolImportance).IsModified = true;

            await Context.SaveChangesAsync();

            return RedirectToPage("./SearchList");
        }
    }
}
