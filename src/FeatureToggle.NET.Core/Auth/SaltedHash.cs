namespace FeatureToggle.NET.Core.Auth
{
	public class SaltedHash
	{
		public string Salt { get; set; }

		public string Hash { get; set; }
	}
}