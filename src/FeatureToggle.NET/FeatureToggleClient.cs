using System;
using FeatureToggle.NET.Core;
using FeatureToggle.NET.Core.Types;

namespace FeatureToggle.NET
{
	public class FeatureToggleClient : IFeatureToggleClient
	{
		public User User { get; set; }

		public Env Environment { get; set; }

		public void Initialise(string key, string environment = null, User user = null)
		{

		}

		public T GetToggledValue<T>(string featureName)
		{
			throw new NotImplementedException();
		}
	}
}