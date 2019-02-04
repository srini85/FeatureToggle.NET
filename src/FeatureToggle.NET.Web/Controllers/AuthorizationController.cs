using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FeatureToggle.NET.Core.Auth;
using FeatureToggle.NET.Core.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace FeatureToggle.NET.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
	    private readonly AuthSettings _settings;
	    private readonly IAuthService _authService;

	    public AuthorizationController(IOptions<AuthSettings> settings, IAuthService authService)
	    {
		    _authService = authService;
		    _settings = settings.Value;
	    }

	    [AllowAnonymous]
	    [HttpPost]
	    public IActionResult RequestToken([FromBody] TokenRequest request)
	    {
		    if (!_authService.IsLoginValid(request.ClientId, request.ClientSecret))
			    return BadRequest("Could not verify credentials");

		    var claims = new[]
		    {
			    new Claim(ClaimTypes.Name, request.ClientId)
		    };

		    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.EncryptionKey));
		    var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

		    var token = new JwtSecurityToken(
			    _settings.Issuer,
			    _settings.Audience,
			    claims,
			    expires: DateTime.Now.AddMinutes(_settings.ExpirationInMinutes),
			    signingCredentials: credentials);

		    return Ok(new
		    {
			    token = new JwtSecurityTokenHandler().WriteToken(token)
		    });

	    }

	    [AllowAnonymous]
	    [HttpPost]
		[Route("create")]
	    public string CreateLogin([FromBody] CreateCredentialRequest value)
	    {
		    return _authService.CreateLogin(value.Email, value.Secret);
	    }
	}
}