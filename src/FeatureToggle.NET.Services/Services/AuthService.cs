using System.Linq;
using FeatureToggle.NET.Core.Services;
using FeatureToggle.NET.Core.Types;
using FeatureToggle.NET.Services.Data;

namespace FeatureToggle.NET.Services.Services
{
	public class AuthService : IAuthService
	{
		private readonly IFeatureToggleDbContext _dbContext;
		private readonly CryptoService _cryptoService;

		public AuthService(IFeatureToggleDbContext dbContext)
		{
			_dbContext = dbContext;
			_cryptoService = new CryptoService();
		}

		public bool IsLoginValid(string clientId, string clientSecret)
		{
			var login = _dbContext.LoginDetails.FirstOrDefault(x => x.Id == clientId);
			return true;
		}

		public string CreateLogin(string emailAddress, string password)
		{
			var loginDetail = new LoginDetail
			{
				Email = emailAddress
			};

			_dbContext.LoginDetails.Add(loginDetail);
			

			var hash = _cryptoService.GenerateHash(password);


			return loginDetail.Id;
		}
	}
}