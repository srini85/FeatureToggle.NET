using System.Collections.Generic;
using FeatureToggle.NET.Core;
using FeatureToggle.NET.Core.Types;
using Microsoft.AspNetCore.Mvc;

namespace FeatureToggle.NET.Web.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		// GET api/user
		[HttpGet]
		public ActionResult<IEnumerable<string>> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/values/someUser
		[HttpGet("{id}")]
		public ActionResult<string> Get(string id)
		{
			return "value";
		}

		// POST api/user
		[HttpPost]
		public void Post([FromBody] User value)
		{
		}

		// PUT api/user/someUser
		[HttpPut("{id}")]
		public void Put(string id, [FromBody] User value)
		{
		}

		// DELETE api/user/someUser
		[HttpDelete("{id}")]
		public void Delete(string id)
		{
		}
	}
}
