namespace FeatureToggle.NET.Core.Checkers
{
	public class EnvironmentContextData : IContextData
	{
		public string Name => "Environment";

		public object Data { get; set; }
	}
}