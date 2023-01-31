using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APBD_zad9.Models;
using APBD_zad9.Models.DTO;
using APBD_zad9.Services;

namespace APBD_zad9.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountsDbRepository repository;

        public AccountsController(IAccountsDbRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDto dto)
        {
            var result = await repository.RegisterAsync(dto);

            return result switch
            {
                DbAnswer.Ok => Ok("Successfully registered!"),
                DbAnswer.PasswordLengthIsNotProper => BadRequest("Password should contain at least 6 characters!"),
                DbAnswer.UserIsAlreadyRegistered => BadRequest("User with the same login is alredy registered!"),
                _ => StatusCode(500)
            };
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserDto dto)
        {
            var result = await repository.LoginAsync(dto);

            return result.DbAnswer switch
            {
                DbAnswer.Ok => Ok(result),
                DbAnswer.BadPassword => Unauthorized("Entered password is wrong!"),
                DbAnswer.UserNotFound => Unauthorized("Entered login is not found!"),
                _ => Unauthorized()
            };
        }

        [HttpPost("updateAccessToken")]
        public async Task<IActionResult> UpdateAccessToken(RefreshTokenDto dto)
        {
            var result = await repository.UpdateAccessTokenAsync(dto);

            return result.DbAnswer switch
            {
                DbAnswer.Ok => Ok(result),
                DbAnswer.RefreshTokenIsExpired => BadRequest("Refresh token is expired!"),
                DbAnswer.UserNotFound => BadRequest("User is not found!"),
                _ => Unauthorized()
            };
        }
    }
}