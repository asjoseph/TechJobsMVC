using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results
        // Add a Results action method to SearchController. 
        //The method should take in two parameters, 
        //specifying the type of search and the search term. 
        //In order for the parameters to be properly passed in by the MVC framework,
        //you'll need to name them appropriately, based on the corresponding form field names.
        //After looking up the search results via the JobData class, 
        //you'll need to pass them into the Views/Search/Index.cshtml view.
        //Note that this is not the default view for this action.
        //You'll also need to pass ListController.columnChoices to the view, as is done in the Index method.
        [HttpPost]
        public IActionResult Results(string searchType = "all", string searchTerm = "")
        {
            

            //if (string.IsNullOrEmpty(searchTerm))
            //{
              //  return View("Index");
            //}
            if (searchType.Equals("all"))
            {
                List<Dictionary<string, string>> Jobs = JobData.FindByValue(searchTerm);

                ViewBag.jobs = Jobs;

                return View("Index");
            }
            else
            {
                List<Dictionary<string, string>> Jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.columns = ListController.columnChoices;

                ViewBag.jobs = Jobs;

                return View("Index");
            }
        }
    }
}