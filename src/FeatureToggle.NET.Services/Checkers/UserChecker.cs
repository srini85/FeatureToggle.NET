using FeatureToggle.NET.Core.Checkers;
using FeatureToggle.NET.Core.Types;

namespace FeatureToggle.NET.Services.Checkers
{
	public class UserChecker : IFeatureCriteriaChecker<string>
	{
		public string Name { get; set; }
		public bool IsValid(Feature feature, string checkParams)
		{
			throw new System.NotImplementedException();
		}
	}
}