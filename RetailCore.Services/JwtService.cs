using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RetailCore.Services
{
	public class JwtService
	{
		private readonly IConfiguration _configuration = null;

		public JwtService(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		/// <summary>
		/// Generate Tokens and compile and the claims based on the provided user object
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		public string GenerateToken(string userID, bool isRememberMe)
		{
			int expiresValue = isRememberMe ? Convert.ToInt16(_configuration["Jwt:Max_Expires"]) : Convert.ToInt16(_configuration["Jwt:Expires"]);
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
			var claims = new[]
			{
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				new Claim(JwtRegisteredClaimNames.Name, userID)
			};
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Issuer = _configuration["Jwt:Issuer"],
				Audience = _configuration["Jwt:Audience"],
				Subject = new ClaimsIdentity(claims),
				Expires = DateTime.Now.AddMinutes(expiresValue),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}


		/// <summary>
		/// Validate the JWT token string and extract out the embedded claims
		/// </summary>
		/// <param name="token"></param>
		/// <returns></returns>
		public ClaimsPrincipal GetPrincipalFromToken(string token)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

			try
			{
				var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(key),
					ValidateIssuer = false,
					ValidateAudience = false,
					ValidateLifetime = true,
					ClockSkew = TimeSpan.Zero
				}, out var validatedToken);

				return principal;
			}
			catch
			{
				return null;
			}
		}
	}
}
