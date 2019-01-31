using FeatureToggle.NET.Core;
using FeatureToggle.NET.Core.Types;

namespace FeatureToggle.NET
{
	public interface IFeatureToggleClient
	{
		User User { get; set; }

		Env Environment { get; set; }

		void Initialise(string key, string environment = null, User user = null);

		T GetToggledValue<T>(string featureName);
	}
}