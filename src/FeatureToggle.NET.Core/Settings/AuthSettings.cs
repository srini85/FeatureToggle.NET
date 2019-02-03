namespace FeatureToggle.NET.Core.Settings
{
	public class AuthSettings
	{
		public string EncryptionKey { get; set; }

		public string Issuer { get; set; }

		public string Audience { get; set; }

		public int ExpirationInMinutes { get; set; }
	}
}
