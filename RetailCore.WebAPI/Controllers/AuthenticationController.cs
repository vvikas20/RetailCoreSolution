using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RetailCore.BusinessObjects.BusinessObjects;
using RetailCore.BusinessObjects.Configurations;
using RetailCore.ServiceContracts;
using RetailCore.WebAPI.RequestParameter;
using RetailCore.WebAPI.ResponseHandler;
using System.Net;
using IAuthenticationService = RetailCore.ServiceContracts.IAuthenticationService;

namespace RetailCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        private readonly ILogger<AuthenticationController> _logger;
        private readonly IAuthenticationService _authenticationService;
        private readonly IJwtService _jwtAuthService;
        private readonly AppSettings _appSettings;

        public AuthenticationController(ILogger<AuthenticationController> logger, IAuthenticationService authenticationService, IJwtService jwtAuthService, IOptions<AppSettings> appSettings)
        {
            _logger = logger;
            _authenticationService = authenticationService;
            _jwtAuthService = jwtAuthService;
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        [Route("token")]

        public APIResponse ValidateUser([FromForm] AuthenticationParameter model)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation($"Valdating user ");

                var base64EncodedBytes = System.Convert.FromBase64String(model.Password);
                string decodedPassword = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);

                User user = _authenticationService.AuthenticateUser(model.Username, decodedPassword);
                if (user == null)
                {
                    return new APIResponse((int)HttpStatusCode.Unauthorized, "Invalid credential");
                }
                else
                {
                    var responsePayload = new { isMFAEnabled = false, access_token = _jwtAuthService.GenerateToken(user.UserId.ToString(), model.IsRememberMe), username = string.Concat(user.FirstName, user.LastName), isAuthenticated = true };
                    return new APIResponse((int)HttpStatusCode.OK, "Authorized", responsePayload);
                }
            }
            else
            {
                return new APIResponse((int)HttpStatusCode.BadRequest, "Invalid User/Password value");
            }
        }

    }
}
