using System;
using Microsoft.AspNetCore.Mvc;

namespace FeatureToggle.NET.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvironmentController : ControllerBase
    {
		[HttpPost]
		public string Post() => "empty";

	    [HttpPost]
	    [Route("/assign")]
	    public string AssignClientToEnvironment()
	    {
			throw new NotImplementedException();
	    }
	}
}