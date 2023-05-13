using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace LeapYearsv3.Models
{
	
		public class Search
		{

			public int SearchId { get; set; }
			public string? Name { get; set; }

			[RegularExpression(@"^\d+$", ErrorMessage = "Please enter a numeric value for the year.")]
			[Range(1899, 2023, ErrorMessage = "The year must be between {1} and {2}.")]
			public int Year { get; set; }
			public DateTime SearchDate { get; set; }
			public string? UserNumber { get; set; }
			public string? UserName { get; set; }

			public Search()
			{
				// Default constructor
			}

			public Search(string? name, int year, IHttpContextAccessor httpContextAccessor)
			{
				Name = name;
				Year = year;
				SearchDate = DateTime.Now;
				if (httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
				{
                var userIdClaim = httpContextAccessor.HttpContext.User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
                if (userIdClaim != null)
                {
                    var userId = userIdClaim.Value;
					UserNumber = userId;
                }
                //UserNumber = httpContextAccessor.HttpContext.User.FindFirstValue("string");
					UserName = httpContextAccessor.HttpContext.User.Identity.Name;
				}
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
