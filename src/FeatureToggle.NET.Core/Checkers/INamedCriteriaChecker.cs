﻿using FeatureToggle.NET.Core.Types;

namespace FeatureToggle.NET.Core.Checkers
{
	public interface INamedCriteriaChecker<in TParams>
	{
		string Name { get; set; }

		bool IsValid(Feature feature, TParams checkParams);
	}
}