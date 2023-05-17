using LeapYearsv3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PagedList;
using System.Drawing.Printing;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using LeapYearsv3.ViewModels;
using Microsoft.Extensions.Configuration.UserSecrets;

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
        [HttpPost]
        public IActionResult RemoveSearch(int SearchId)
        {
            _searchRepository.DeleteSearch(SearchId);
            return RedirectToAction("IndexList");
        }
        public ViewResult IndexList(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ListAndUserVm ListnUser = new ListAndUserVm();
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
			IEnumerable<Search> searches_=_searchRepository.SearchList.Reverse();
            ListnUser.List=searches_.ToPagedList(pageNumber, pageSize);
            if (_contextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                var userIdClaim = _contextAccessor.HttpContext.User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
                if (userIdClaim != null)
                {
                    var userId = userIdClaim.Value;
                    ListnUser.UserNumber=userId;
                }
            }
           
                return View("Views/List/ListView.cshtml", ListnUser);
		}

		public IActionResult GetList()
        {

           return View("Views/List/Index.cshtml", _searchRepository.SearchList);
        }

    }
}
