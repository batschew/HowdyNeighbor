using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HowdyNeighbor.Pages
{
    [AllowAnonymous]
    public class AgeDemographicsNotLoggedInModel : PageModel
    {
        public void OnGet()
        {
            string searchString = TempData["searchString"] as string;
            TempData.Keep();
            ViewData["searchString"] = searchString;
        }
        public IActionResult OnPostSearchListNotLoggedIn(string ageImportance)
        {
            TempData["ageImportance"] = ageImportance;
            TempData.Keep();
            return RedirectToPage("/SearchListNotLoggedIn");
        }
    }
}