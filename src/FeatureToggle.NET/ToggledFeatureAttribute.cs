using System;

namespace FeatureToggle.NET
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public class ToggledFeatureAttribute : Attribute
	{
		public bool WhenToggled { get; set; }

		public string Name { get; set; }
	}
}