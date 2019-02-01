using FeatureToggle.NET.Core.Types;
using FeatureToggle.NET.Store.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FeatureToggle.NET.Store
{
	public class FeatureToggleDbContext : DbContext, IFeatureToggleDbContext
	{
		public DbSet<Env> Environments { get; set; }

		public DbSet<FeatureValue> FeatureValues { get; set; }

		public DbSet<Feature> Features { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("Data Source=FeatureToggle.db");
		}
	}
}
