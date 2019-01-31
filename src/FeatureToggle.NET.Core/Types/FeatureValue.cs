using System;

namespace FeatureToggle.NET.Core.Types
{
	public class FeatureValue<T> 
	 where T : new()
	{
		public Type Type => typeof(T);

		public T Value { get; set; }

		public FeatureValue<object> AsObject()
		{
			return new FeatureValue<object> {Value = Value};
		}
	}
}