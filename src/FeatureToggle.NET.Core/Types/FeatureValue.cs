using System;

namespace FeatureToggle.NET.Core.Types
{
	public class FeatureValue<T>
	{
		public string Id { get; set; }

		public Type Type => typeof(T);

		public T Value { get; set; }

		public FeatureValue<object> AsObject()
		{
			return new FeatureValue<object> {Id = Id, Value = Value};
		}
	}
	public class FeatureValue
	{
		public string Id { get; set; }

		public string Type { get; set; }

		public string Value { get; set; }
	}
}