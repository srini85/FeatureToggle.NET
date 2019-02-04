using System.Linq;
using FeatureToggle.NET.Core.Auth;
using FeatureToggle.NET.Core.Services;
using FeatureToggle.NET.Core.Types;
using FeatureToggle.NET.Services.Data;

namespace FeatureToggle.NET.Services.Services
{
	public class AuthService : IAuthService
	{
		private readonly IFeatureToggleDbContext _dbContext;
		private readonly CryptoService _cryptoService;
		private readonly ICryptoService _service;

		public AuthService(IFeatureToggleDbContext dbContext, ICryptoService cryptoService)
		{
			_service = cryptoService;
			_dbContext = dbContext;
			_cryptoService = new CryptoService();
		}

		public bool IsLoginValid(string clientId, string clientSecret)
		{
			var login = _dbContext.LoginDetails.FirstOrDefault(x => x.Id == clientId);
			return login != null 
			       && _cryptoService.VerifyPasswordWithHash(clientSecret, new SaltedHash {Hash = login.Hash, Salt = login.Salt});
		}

		public string CreateLogin(string emailAddress, string password)
		{
			var loginDetail = new LoginDetail
			{
				Email = emailAddress
			};

			_dbContext.LoginDetails.Add(loginDetail);
			

			var saltedHash = _cryptoService.GenerateHash(password);
			loginDetail.Salt = saltedHash.Salt;
			loginDetail.Hash = saltedHash.Hash;

			_dbContext.SaveChanges();

			return loginDetail.Id;
		}
	}
}