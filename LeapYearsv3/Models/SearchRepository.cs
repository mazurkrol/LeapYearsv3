using Microsoft.EntityFrameworkCore;

namespace LeapYearsv3.Models
{
	public class SearchRepository : ISearchRepository
	{
		private readonly LeapYearsDbContext _leapYearsDbContext;
		
		public SearchRepository(LeapYearsDbContext leapYearsDbContext)
		{
			_leapYearsDbContext = leapYearsDbContext;
		}
		public IEnumerable<Search> SearchList 
		{
			get
			{
				return _leapYearsDbContext.Searches.Include(search => search.UserNumber);
			}
		}
		public void AddSearch(Search search)
		{
			//var newSearch = new Search(search.SearchId, search.Name, search.Year, search.SearchDate, search.UserNumber);
			_leapYearsDbContext.Searches.Add(search);
			_leapYearsDbContext.SaveChanges();
		}
	}
}
