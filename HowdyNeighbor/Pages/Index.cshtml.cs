using HowdyNeighbor.Authorization;
using HowdyNeighbor.Data;
using HowdyNeighbor.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HowdyNeighbor.Pages
{
    [AllowAnonymous]
    public class IndexModel : BasePageModel
    {
        public IndexModel(ApplicationDbContext context, IAuthorizationService authorizationService, UserManager<IdentityUser> userManager) : base(context, authorizationService, userManager)
        {
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public SearchList SearchList { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            SearchList.OwnerID = UserManager.GetUserId(User);
            var isAuthorized = await AuthorizationService.AuthorizeAsync(User, SearchList, Operations.Create);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            Context.SearchList.Add(SearchList);
            await Context.SaveChangesAsync();

            return RedirectToPage("./SearchList");
        }
    }
}
