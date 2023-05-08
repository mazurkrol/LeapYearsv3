using Microsoft.EntityFrameworkCore;

namespace LeapYearsv3.Models
{
	public class LeapYearsDbContext : DbContext
	{
		public LeapYearsDbContext(DbContextOptions<LeapYearsDbContext> options) : base()
		{ 
		}
		public DbSet<Search> Searches { get; set; }
	}
}
