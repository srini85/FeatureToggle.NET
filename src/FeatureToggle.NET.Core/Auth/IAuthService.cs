namespace FeatureToggle.NET.Core.Auth
{
	public interface IAuthService
	{
		bool IsLoginValid(string clientId, string clientSecret);

		string CreateLogin(string emailAddress, string password);
	}
}