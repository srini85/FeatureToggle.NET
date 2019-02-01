using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FeatureToggle.NET.Core.Types.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace FeatureToggle.NET.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
	    [AllowAnonymous]
	    [HttpPost]
	    public IActionResult RequestToken([FromBody] TokenRequest request)
	    {
		    if (request.ClientId == "srini" && request.ClientSecret == "secret")
		    {
			    var claims = new[]
			    {
				    new Claim(ClaimTypes.Name, request.ClientId)
			    };

			    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("some-dummy-key-that-should-come-from-app-settings"));
			    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			    var token = new JwtSecurityToken(
				    "sriniapps.com",
				    "sriniapps.com",
				    claims,
				    expires: DateTime.Now.AddMinutes(30),
				    signingCredentials: creds);

			    return Ok(new
			    {
				    token = new JwtSecurityTokenHandler().WriteToken(token)
			    });
		    }

		    return BadRequest("Could not verify username and password");
	    }
	}
}