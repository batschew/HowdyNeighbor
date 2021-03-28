using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HowdyNeighbor.Data;
using HowdyNeighbor.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HowdyNeighbor.Pages
{
    public class MovingListModel : BasePageModel
    {
        public MovingListModel(ApplicationDbContext context, IAuthorizationService authorizationService, UserManager<IdentityUser> userManager) : base(context, authorizationService, userManager)
        {
        }

        public IList<ChecklistTask> ChecklistTask { get; set; }

        public async Task OnGetAsync()
        {
            var checklistTasks = from task in Context.ChecklistTask select task;
            var currentUserId = UserManager.GetUserId(User);
            checklistTasks = checklistTasks.Where(task => task.OwnerID == currentUserId);
            ChecklistTask = await checklistTasks.ToListAsync();
        }
    }
}
