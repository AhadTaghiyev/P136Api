using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ApiIntro.Service.Dtos.Accounts;
using ApiIntro.Service.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiIntro.Apps.Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public AccountsController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegisterDto dto)
        {
            var result = await _identityService.Register(dto);
            return StatusCode(result.StatusCode,result);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginDto dto)
        {
            var result = await _identityService.Login(dto);
            return StatusCode(result.StatusCode,result);
        }
    }
}


