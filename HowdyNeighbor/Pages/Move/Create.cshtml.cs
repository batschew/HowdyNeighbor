using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HowdyNeighbor.Data;
using HowdyNeighbor.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using HowdyNeighbor.Authorization;

namespace HowdyNeighbor.Pages.Move
{
    public class CreateModel : BasePageModel
    {

        public CreateModel(ApplicationDbContext context, IAuthorizationService authorizationService, UserManager<IdentityUser> userManager) : base(context, authorizationService, userManager)
        {
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ChecklistTask ChecklistTask { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ChecklistTask.OwnerID = UserManager.GetUserId(User);
            var isAuthorized = await AuthorizationService.AuthorizeAsync(User, ChecklistTask, Operations.Create);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            Context.ChecklistTask.Add(ChecklistTask);
            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
