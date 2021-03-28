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
    public class DeleteSearchListModel : BasePageModel
    {
        private readonly HowdyNeighbor.Data.ApplicationDbContext _context;
        public DeleteSearchListModel(ApplicationDbContext context, IAuthorizationService authorizationService, UserManager<IdentityUser> userManager) : base(context, authorizationService, userManager)
        {
            _context = context;
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

            var isAuthorized = await AuthorizationService.AuthorizeAsync(User, SearchList, Operations.Delete);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var searchList = await Context.SearchList.AsNoTracking().FirstOrDefaultAsync(list => list.ID == id);
            if (searchList == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(User, searchList, Operations.Delete);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            Context.SearchList.Remove(searchList);
            await Context.SaveChangesAsync();

            return RedirectToPage("./SearchList");
        }
    }
}
