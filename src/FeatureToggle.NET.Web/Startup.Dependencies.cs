using FeatureToggle.NET.Core.Auth;
using FeatureToggle.NET.Core.Services;
using FeatureToggle.NET.Services.Data;
using FeatureToggle.NET.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FeatureToggle.NET.Web
{
	public partial class Startup
	{
		public void SetupDependencies(IServiceCollection services)
		{
			services.AddSingleton(Configuration);
			services.AddScoped<IFeatureToggleDbContext, SqlLiteDbContext>();
			services.AddScoped<IFeatureValueService, FeatureValueService>();
			services.AddScoped<IAuthService, AuthService>();
			services.AddScoped<ICryptoService, CryptoService>();
		}
	}
}