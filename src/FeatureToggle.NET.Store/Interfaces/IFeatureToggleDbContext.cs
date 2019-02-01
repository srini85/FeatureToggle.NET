using FeatureToggle.NET.Core.Types;
using Microsoft.EntityFrameworkCore;

namespace FeatureToggle.NET.Store.Interfaces
{
	public interface IFeatureToggleDbContext
	{
		DbSet<Env> Environments { get; set; }

		DbSet<FeatureValue> FeatureValues { get; set; }

		int SaveChanges();
	}
}