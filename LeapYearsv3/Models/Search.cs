namespace LeapYearsv3.Models
{
	
		public class Search
		{
			public int SearchId { get; set; }
			public int Name { get; set; }
			public int Year { get; set; }
			public DateTime SearchDate { get; set; }
			public int? UserNumber { get; set; }

			public Search()
			{
				// Default constructor
			}

			public Search(int searchId, int name, int year, DateTime searchDate, int? userNumber)
			{
				SearchId = searchId;
				Name = name;
				Year = year;
				SearchDate = DateTime.Now;
				UserNumber = userNumber;
			}
		}
	
}
