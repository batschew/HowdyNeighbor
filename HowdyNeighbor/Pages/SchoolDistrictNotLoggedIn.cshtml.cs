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
    public class SchoolDistrictNotLoggedInModel : PageModel
    {
        public IActionResult OnGet()
        {
            string searchString = TempData["searchString"] as string;
            TempData.Keep();
            ViewData["searchString"] = searchString;

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Page();
        }

        public IActionResult OnPostSearchListNotLoggedIn(string schoolImportance)
        {
            TempData["schoolImportance"] = schoolImportance;
            TempData.Keep();

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return RedirectToPage("/SearchListNotLoggedIn");
        }
    }
}