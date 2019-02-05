using System;
using FeatureToggle.NET.Core.Checkers;
using FeatureToggle.NET.Core.Types;

namespace FeatureToggle.NET.Services.Checkers
{
	public class TimePeriodChecker : IFeatureCriteriaChecker<TimePeriod>
	{
		public string Name { get; set; }
		public bool IsValid(Feature feature, TimePeriod checkParams)
		{
			throw new NotImplementedException();
		}
	}
}