using System.Text;
using FeatureToggle.NET.Core.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace FeatureToggle.NET.Web
{
	public partial class Startup
	{
		public void SetupAuth(IServiceCollection services)
		{
			var authSettings = new AuthSettings();
			services.Configure<AuthSettings>(Configuration.GetSection("Auth"));
			Configuration.GetSection("Auth").Bind(authSettings);

			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(options =>
				{
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuer = true,
						ValidateAudience = true,
						ValidateLifetime = true,
						ValidateIssuerSigningKey = true,
						ValidIssuer = authSettings.Issuer,
						ValidAudience = authSettings.Audience,
						IssuerSigningKey = new SymmetricSecurityKey(
							Encoding.UTF8.GetBytes(authSettings.EncryptionKey))
					};
				});

		}
	}
}