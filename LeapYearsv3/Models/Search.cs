using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LeapYearsv3.Models
{
	
		public class Search
		{

			public int SearchId { get; set; }
			public string? Name { get; set; }
			public int Year { get; set; }
			public DateTime SearchDate { get; set; }
			public int? UserNumber { get; set; }

			public Search()
			{
				// Default constructor
			}

			public Search(string? name, int year)
			{
				Name = name;
				Year = year;
				SearchDate = DateTime.Now;
			}

			public string IsLeap()
			{
			string sentence = Name+" urodzil sie w roku "+Year+ " byl to rok ";
            if (Year%100==0 && Year%400!=0)
                return sentence+="nieprzestepny";
            else
            if (Year%4==0)
                return sentence+="przestepny";
            else
                return sentence+="nieprzestepny";
			}
		}
	
}
