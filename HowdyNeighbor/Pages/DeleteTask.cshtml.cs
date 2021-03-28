using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HowdyNeighbor.Data;
using HowdyNeighbor.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HowdyNeighbor.Authorization;

namespace HowdyNeighbor.Pages
{
    public class DeleteTaskModel : BasePageModel
    {
        private readonly HowdyNeighbor.Data.ApplicationDbContext _context;

        public DeleteTaskModel(ApplicationDbContext context, IAuthorizationService authorizationService, UserManager<IdentityUser> userManager) : base(context, authorizationService, userManager)
        {
            _context = context;
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

            var isAuthorized = await AuthorizationService.AuthorizeAsync(User, ChecklistTask, Operations.Delete);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var checklistTask = await Context.ChecklistTask.AsNoTracking().FirstOrDefaultAsync(task => task.ID == id);
            if (checklistTask == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(User, checklistTask, Operations.Delete);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            Context.ChecklistTask.Remove(checklistTask);
            await Context.SaveChangesAsync();

            return RedirectToPage("./MovingList");
        }
    }
}
