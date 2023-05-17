using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
				return _leapYearsDbContext.Searches;
			}
		}
		public void AddSearch(Search search)
		{
			//var newSearch = new Search(search.SearchId, search.Name, search.Year, search.SearchDate, search.UserNumber);
			_leapYearsDbContext.Searches.Add(search);
			_leapYearsDbContext.SaveChanges();
		}

        public void DeleteSearch(int SearchId)
        {
            var _search = _leapYearsDbContext.Searches.Find(SearchId);
            if (_search != null)
            {
                _search.SearchId = SearchId; // Set a permanent value for SearchId
                _leapYearsDbContext.Searches.Remove(_search);
                _leapYearsDbContext.SaveChanges();
            }
			else
			{
				throw new InvalidOperationException();
			}
            //_leapYearsDbContext.Searches.Remove(search);
            //_leapYearsDbContext.SaveChanges();
        }
    }
}
