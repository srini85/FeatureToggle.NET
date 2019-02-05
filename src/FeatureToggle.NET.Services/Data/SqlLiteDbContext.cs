using FeatureToggle.NET.Core.Types;
using Microsoft.EntityFrameworkCore;

namespace FeatureToggle.NET.Services.Data
{
	public class SqlLiteDbContext : FeatureToggleDbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("Data Source=FeatureToggle.db");
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<ToggleCriterion>()
				.Ignore(x => x.Criteria);

			builder.Entity<ToggleCriterion>()
				.Property(x => x.SerializedCriteria);
		}
	}
}
