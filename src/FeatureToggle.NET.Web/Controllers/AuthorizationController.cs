using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FeatureToggle.NET.Core.Auth;
using FeatureToggle.NET.Core.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace FeatureToggle.NET.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
	    private readonly AuthSettings _settings;

	    public AuthorizationController(IOptions<AuthSettings> settings)
	    {
		    _settings = settings.Value;
		}

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

			    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.EncryptionKey));
			    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			    var token = new JwtSecurityToken(
				    _settings.Issuer,
				    _settings.Audience,
				    claims,
				    expires: DateTime.Now.AddMinutes(_settings.ExpirationInMinutes),
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