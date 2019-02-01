using FeatureToggle.NET.Core.Services;
using FeatureToggle.NET.Core.Types;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FeatureToggle.NET.Web.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	public class FeatureValueController : Controller
	{
		private readonly IFeatureValueService _featureValueService;

		public FeatureValueController(IFeatureValueService featureValueService)
		{
			_featureValueService = featureValueService;
		}

		[HttpGet]
		public FeatureValue<object> Get()
		{
			return (new FeatureValue<Env> {Value = new Env{Description = "test", FriendlyName = "prod"}}).AsObject();
		}

		[HttpPost]
		public string Add([FromBody] FeatureValue<object> value)
		{
			dynamic featureValue;
			switch (value.Value)
			{
				case bool booleanVal:
					featureValue = new FeatureValue<bool>{Value = booleanVal};
					break;
				case long longVal:
					featureValue = new FeatureValue<long> {Value = longVal};
					break;
				case string stringVal:
					featureValue = new FeatureValue<string> { Value = stringVal };
					break;
				default:
					featureValue = value;
					break;
			}

			return _featureValueService.AddFeatureValue(featureValue);
		}
	}
}