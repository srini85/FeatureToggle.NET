using FeatureToggle.NET;

namespace SampleFeatureToggledService
{
	[ToggledFeature(Name = "localised-greeter", WhenToggled = false)]
	public class Greeter : IGreeter
	{
		public string Greet()
		{
			return "Hello";
		}
	}
}