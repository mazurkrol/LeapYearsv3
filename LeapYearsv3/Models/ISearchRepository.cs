namespace LeapYearsv3.Models
{
	public interface ISearchRepository
	{
		IEnumerable<Search> SearchList { get;}
		void AddSearch(Search search);
		void DeleteSearch(int SearchId);

    }
}
