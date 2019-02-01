using FeatureToggle.NET.Core.Types;

namespace FeatureToggle.NET.Core.Services
{
	public interface IFeatureValueService
	{
		FeatureValue GetFeatureValueById(string id);

		string AddFeatureValue(FeatureValue value);
		string AddFeatureValue<T>(FeatureValue<T> value);
	}
}