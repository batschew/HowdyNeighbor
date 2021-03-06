using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HowdyNeighbor.Pages
{
    [AllowAnonymous]
    public class SearchListNotLoggedInModel : PageModel
    {
        public IActionResult OnGet()
        {
            string searchString = TempData["searchString"] as string;
            TempData.Keep();
            ViewData["searchString"] = searchString;

            string schoolImportance = TempData["schoolImportance"] as string;
            TempData.Keep();
            ViewData["schoolImportance"] = schoolImportance;

            string crimeImportance = TempData["crimeImportance"] as string;
            TempData.Keep();
            ViewData["crimeImportance"] = crimeImportance;

            string trafficImportance = TempData["trafficImportance"] as string;
            TempData.Keep();
            ViewData["trafficImportance"] = trafficImportance;

            string ageImportance = TempData["ageImportance"] as string;
            TempData.Keep();
            ViewData["ageImportance"] = ageImportance;

            string pointsOfInterestImportance = TempData["pointsOfInterestImportance"] as string;
            TempData.Keep();
            ViewData["pointsOfInterestImportance"] = pointsOfInterestImportance;

            string costOfLivingImportance = TempData["costOfLivingImportance"] as string;
            TempData.Keep();
            ViewData["costOfLivingImportance"] = costOfLivingImportance;

            string internetProvidersImportance = TempData["internetProvidersImportance"] as string;
            TempData.Keep();
            ViewData["internetProvidersImportance"] = internetProvidersImportance;

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Page();
        }

        public IActionResult OnPostSaveChecklistAsync()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return RedirectToPage("/Index");
        }

        public IActionResult OnPostTrafficDensity(string searchString)
        {
            TempData["searchString"] = searchString;
            TempData.Keep();
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return RedirectToPage("/TrafficDensity");
        }

        public IActionResult OnPostAgeDemographics(string searchString)
        {
            TempData["searchString"] = searchString;
            TempData.Keep();
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return RedirectToPage("/AgeDemographics");
        }

        public IActionResult OnPostSchoolDistrict(string searchString)
        {
            TempData["searchString"] = searchString;
            TempData.Keep();
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return RedirectToPage("/SchoolDistrict");
        }

        public IActionResult OnPostPointsOfInterest(string searchString)
        {
            TempData["searchString"] = searchString;
            TempData.Keep();
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return RedirectToPage("/PointsOfInterest");
        }

        public IActionResult OnPostCostOfLiving(string searchString)
        {
            TempData["searchString"] = searchString;
            TempData.Keep();
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return RedirectToPage("/CostOfLiving");
        }

        public IActionResult OnPostInternetProviders(string searchString)
        {
            TempData["searchString"] = searchString;
            TempData.Keep();
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return RedirectToPage("/InternetProviders");
        }
    }
}
