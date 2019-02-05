using Newtonsoft.Json;

namespace FeatureToggle.NET.Core.Types
{
	public class ToggleCriterion
	{
		public string Id { get; set; }
		
		public string Type { get; set; }

		private object _criteria;
		public object Criteria
		{
			get => _criteria;
			set
			{
				SerializedCriteria = JsonConvert.SerializeObject(value);
				_criteria = value;
			}
		}
		public string SerializedCriteria { get; private set; }
	}
}