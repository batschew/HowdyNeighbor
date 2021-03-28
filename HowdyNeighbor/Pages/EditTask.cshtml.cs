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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using HowdyNeighbor.Authorization;

namespace HowdyNeighbor.Pages
{
    public class EditTaskModel : BasePageModel
    {
        public EditTaskModel(ApplicationDbContext context, IAuthorizationService authorizationService, UserManager<IdentityUser> userManager) : base(context, authorizationService, userManager)
        {
        }

        [BindProperty]
        public ChecklistTask ChecklistTask { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            ChecklistTask = await Context.ChecklistTask.FirstOrDefaultAsync(task => task.ID == id);

            if (ChecklistTask == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(User, ChecklistTask, Operations.Update);
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

            var checklistTask = await Context.ChecklistTask.AsNoTracking().FirstOrDefaultAsync(task => task.ID == id);

            if (checklistTask == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(User, checklistTask, Operations.Update);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            ChecklistTask.OwnerID = checklistTask.OwnerID;
            Context.Attach(ChecklistTask).State = EntityState.Modified;

            await Context.SaveChangesAsync();

            return RedirectToPage("./MovingList");
        }
    }
}
