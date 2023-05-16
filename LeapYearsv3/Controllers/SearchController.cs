using LeapYearsv3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PagedList;

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

        public ViewResult IndexList(string sortOrder, string currentFilter, string searchString, int? page)
        {
			ViewBag.CurrentSort = sortOrder;
			if (searchString != null)
			{
				page = 1;
			}
			else
			{
				searchString = currentFilter;
			}

			ViewBag.CurrentFilter = searchString;
			int pageSize = 20;
			int pageNumber = (page ?? 1);
			IEnumerable<Search> searches_=_searchRepository.SearchList;
			return View("Views/List/ListView.cshtml", searches_.ToPagedList(pageNumber, pageSize));
		}

		public IActionResult GetList()
        {

           return View("Views/List/Index.cshtml", _searchRepository.SearchList);
        }

    }
}
