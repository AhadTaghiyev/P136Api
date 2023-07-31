using System;
using ApiIntro.Service.Dtos.Accounts;
using ApiIntro.Service.Responses;

namespace ApiIntro.Service.Services.Interfaces
{
	public interface IIdentityService
	{
		public Task<ApiResponse> Register(RegisterDto dto);
		public Task<ApiResponse> Login(LoginDto dto);
    }
}

