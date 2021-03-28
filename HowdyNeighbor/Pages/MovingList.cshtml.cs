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
using Microsoft.EntityFrameworkCore;

namespace HowdyNeighbor.Pages
{
    public class MovingListModel : BasePageModel
    {
        public MovingListModel(ApplicationDbContext context, IAuthorizationService authorizationService, UserManager<IdentityUser> userManager) : base(context, authorizationService, userManager)
        {
        }

        public IList<ChecklistTask> ChecklistTasks { get; set; }

        [BindProperty]
        public ChecklistTask ChecklistTask { get; set; }

        public async Task OnGetAsync()
        {
            var checklistTasks = from task in Context.ChecklistTask select task;
            var currentUserId = UserManager.GetUserId(User);
            checklistTasks = checklistTasks.Where(task => task.OwnerID == currentUserId);
            ChecklistTasks = await checklistTasks.ToListAsync();
        }

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

            return RedirectToPage("./MovingList");
        }
    }
}
