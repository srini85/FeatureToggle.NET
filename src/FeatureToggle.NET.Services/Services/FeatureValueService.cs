using System.Linq;
using FeatureToggle.NET.Core.Services;
using FeatureToggle.NET.Core.Types;
using FeatureToggle.NET.Services.Data;
using Newtonsoft.Json;

namespace FeatureToggle.NET.Services.Services
{
	public class FeatureValueService : IFeatureValueService
	{
		private readonly IFeatureToggleDbContext _dbContext;

		public FeatureValueService(IFeatureToggleDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public FeatureValue GetFeatureValueById(string id)
		{
			return _dbContext.FeatureValues.FirstOrDefault(x => x.Id == id);
		}

		public string AddFeatureValue(FeatureValue value)
		{
			_dbContext.FeatureValues.Add(value);
			_dbContext.SaveChanges();
			return value.Id;
		}

		public string AddFeatureValue<T>(FeatureValue<T> value)
		{
			var featureValue = new FeatureValue
			{
				Type = value.Type.ToString(),
				Value = JsonConvert.SerializeObject(value.Value)
			};
			
			return AddFeatureValue(featureValue);
		}
	}
}