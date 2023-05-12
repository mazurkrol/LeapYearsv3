using LeapYearsv3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
namespace LeapYearsv3.Controllers
{
	public class SearchController : Controller
	{
        private readonly ISearchRepository _searchRepository;

        public SearchController(ISearchRepository searchRepository)
        {
            _searchRepository=searchRepository;
        }

        [HttpPost]
        public IActionResult PerformSearch(string? name, int year)
        {
            Search search = new Search(name,year);
            _searchRepository.AddSearch(search);
            return View("Views/Home/Index.cshtml", search);
        }
    }
}
