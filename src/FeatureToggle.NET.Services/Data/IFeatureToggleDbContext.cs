using FeatureToggle.NET.Core.Types;
using Microsoft.EntityFrameworkCore;

namespace FeatureToggle.NET.Services.Data
{
	public interface IFeatureToggleDbContext
	{
		DbSet<Env> Environments { get; set; }

		DbSet<FeatureValue> FeatureValues { get; set; }
		DbSet<LoginDetail> LoginDetails { get; set; }

		int SaveChanges();
	}
}