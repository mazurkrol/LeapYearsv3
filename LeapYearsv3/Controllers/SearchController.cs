using LeapYearsv3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
namespace LeapYearsv3.Controllers
{
	public class SearchController : Controller
	{
        private readonly ISearchRepository _searchRepository;
        private readonly IHttpContextAccessor _contextAccessor;

        public SearchController(ISearchRepository searchRepository,IHttpContextAccessor contextAccessor)
        {
            _searchRepository=searchRepository;
            _contextAccessor=contextAccessor;
        }

        [HttpPost]
        public IActionResult PerformSearch(string? name, int year)
        {
            Search search = new Search(name,year,_contextAccessor);
            _searchRepository.AddSearch(search);
            return View("Views/Home/Index.cshtml", search);
        }
    }
}
