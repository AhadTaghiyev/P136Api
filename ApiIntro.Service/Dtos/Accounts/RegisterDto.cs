using System;
namespace ApiIntro.Service.Dtos.Accounts
{
	public class RegisterDto
	{
		public string Username { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string Confirmpassword { get; set; }
    }
}

