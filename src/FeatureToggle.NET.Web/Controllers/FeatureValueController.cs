using FeatureToggle.NET.Core;
using FeatureToggle.NET.Core.Types;
using Microsoft.AspNetCore.Mvc;

namespace FeatureToggle.NET.Web.Controllers
{
	[Route("api/[controller]")]
	public class FeatureValueController : Controller
	{
		[HttpGet]
		public FeatureValue<object> Get()
		{

			return (new FeatureValue<Env> {Value = new Env{Description = "test", FriendlyName = "prod"}}).AsObject();
		}
	}
}