using FeatureToggle.NET.Core.Types;
using Microsoft.EntityFrameworkCore;

namespace FeatureToggle.NET.Services.Data
{
	public class FeatureToggleDbContext : DbContext, IFeatureToggleDbContext
	{
		public FeatureToggleDbContext()
		{
		}

		public FeatureToggleDbContext(DbContextOptions<FeatureToggleDbContext> options)
			: base(options)
		{
		}

		public DbSet<Env> Environments { get; set; }

		public DbSet<FeatureValue> FeatureValues { get; set; }

		public DbSet<Feature> Features { get; set; }

		public DbSet<User> Users { get; set; }

		public DbSet<LoginDetail> LoginDetails { get; set; }
	}
}
