namespace FeatureToggle.NET.Core.Checkers
{
	public abstract class FeatureCriteriaChecker
	{
		protected internal Context Context;

		protected FeatureCriteriaChecker(Context context)
		{
			Context = context;
		}
	}
}