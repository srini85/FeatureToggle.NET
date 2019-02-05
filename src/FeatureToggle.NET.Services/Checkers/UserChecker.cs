using System;
using FeatureToggle.NET.Core.Checkers;
using FeatureToggle.NET.Core.Types;

namespace FeatureToggle.NET.Services.Checkers
{
	public class UserChecker : FeatureCriteriaChecker, INamedCriteriaChecker<string>
	{
		public UserChecker(Context context) : base(context)
		{
		}

		public string Name { get; set; }

		public bool IsValid(Feature feature, string checkParams)
		{
			throw new NotImplementedException();
		}
	}
}