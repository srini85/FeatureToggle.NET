using System.Collections.Generic;
using System.Linq;

namespace FeatureToggle.NET.Core.Checkers
{
	public class Context
	{
		public List<IContextData> Data { get; set; }

		public Context()
		{
			Data = new List<IContextData>();	
		}

		public void Add(IContextData data)
		{
			Data.Add(data);
		}

		public IContextData Get(string key)
		{
			return Data.FirstOrDefault(x => x.Name == key);
		}
	}
}