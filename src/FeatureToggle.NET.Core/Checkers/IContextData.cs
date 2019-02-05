namespace FeatureToggle.NET.Core.Checkers
{
	public interface IContextData
	{
		string Name { get; }

		object Data { get; set; }
	}
}