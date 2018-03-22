using FeatureToggle.NET;

namespace SampleFeatureToggledService
{
	[ToggledFeature(Name = "localised-greeter", WhenToggled = true)]
	public class AussieGreeter : IGreeter
	{
		public string Greet()
		{
			return "G'day mate";
		}
	}
}