using FeatureToggle.NET.Core.Types;
using Microsoft.EntityFrameworkCore;

namespace FeatureToggle.NET.Services.Data
{
	public class FeatureToggleDbContext : DbContext, IFeatureToggleDbContext
	{
		public DbSet<Env> Environments { get; set; }

		public DbSet<FeatureValue> FeatureValues { get; set; }

		public DbSet<Feature> Features { get; set; }

		public DbSet<User> Users { get; set; }

		public DbSet<LoginDetail> LoginDetails { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("Data Source=FeatureToggle.db");
		}
	}
}
