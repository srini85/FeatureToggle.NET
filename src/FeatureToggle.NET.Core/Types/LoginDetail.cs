namespace FeatureToggle.NET.Core.Types
{
	public class LoginDetail
	{
		public string Id { get; set; }

		public string Email { get; set; }

		public string Salt { get; set; }

		public string Hash { get; set; }
	}
}