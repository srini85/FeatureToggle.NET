namespace FeatureToggle.NET.Core.Auth
{
	public interface ICryptoService
	{
		SaltedHash GenerateHash(string password);
	}
}