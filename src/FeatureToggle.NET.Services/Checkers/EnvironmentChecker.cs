using FeatureToggle.NET.Core.Checkers;
using FeatureToggle.NET.Core.Types;

namespace FeatureToggle.NET.Services.Checkers
{
	public class EnvironmentChecker : FeatureCriteriaChecker, INamedCriteriaChecker<string>
	{
		public string Name { get; set; }

		public bool IsValid(Feature feature, string checkParams)
		{
			var currentEnv = Context.Get("Environment");
			return currentEnv != null && (currentEnv.Data as string) == checkParams;
		}

		public EnvironmentChecker(Context context) : base(context)
		{
		}
	}
}