using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HowdyNeighbor.Data;
using HowdyNeighbor.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HowdyNeighbor.Pages
{
    public class SearchListModel : BasePageModel
    {
        public SearchListModel(ApplicationDbContext context, IAuthorizationService authorizationService, UserManager<IdentityUser> userManager) : base(context, authorizationService, userManager)
        {
        }

        public IList<SearchList> SearchList { get; set; }

        public async Task OnGetAsync()
        {
            var searchList = from list in Context.SearchList select list;
            var currentUserId = UserManager.GetUserId(User);
            searchList = searchList.Where(task => task.OwnerID == currentUserId);
            SearchList = await searchList.ToListAsync();
        }
    }
}
