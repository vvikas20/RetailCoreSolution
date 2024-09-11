using System.ComponentModel.DataAnnotations;

namespace RetailCore.WebAPI.RequestParameter
{
	public class AuthenticationParameter
	{
		[Required]
		[MaxLength(50)]
		public required string Username { get; set; }
		[Required]
		[MaxLength(40)]
		public required string Password { get; set; }
		public bool IsRememberMe { get; set; } = false;
	}
}
