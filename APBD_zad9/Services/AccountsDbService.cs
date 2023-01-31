
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using APBD_zad9.Models.DTO;
using APBD_zad9.Models;
using APBD_zad9.Services;

namespace APBD_zad9.Services
{
    public class AccountsDbService : IAccountsDbRepository
    {
        private readonly DatabaseContext _context;
        private readonly IConfiguration _configuration;

        public AccountsDbService(DatabaseContext context, IConfiguration configuration)
        {
            this._context = context;
            this._configuration = configuration;
        }

        public async Task<DbAnswer> RegisterAsync(UserDto dto)
        {
            if (dto.Password.Length < 6) return DbAnswer.PasswordLengthIsNotProper;

            object checkUser = await _context.User.FirstOrDefaultAsync(e => e.Login == dto.Login);
            if (checkUser != null) return DbAnswer.UserIsAlreadyRegistered;

            Tuple<string, string> hashedPwdAndSalt;
            hashedPwdAndSalt = SecurityHelper.GetHashedPasswordAndSalt(dto.Password);
            var user = new User(login: dto.Login, password: hashedPwdAndSalt.Item1, salt: hashedPwdAndSalt.Item2,
                refreshToken: Guid.NewGuid().ToString(), rerfreshTokenExpiration: DateTime.Now.AddHours(12));

            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();

            return DbAnswer.Ok;
        }

        public async Task<LoginHelper> LoginAsync(UserDto dto)
        {
            object wantedUser;
            wantedUser = await _context.User.FirstOrDefaultAsync(e => e.Login == dto.Login);
            if (wantedUser == null)
                return new LoginHelper(DbAnswer.UserNotFound);

            if (wantedUser.Password == SecurityHelper.GetHashedSaltedPassword(dto.Password, wantedUser.Salt))
            {
                var token = GetToken();

                wantedUser.RefreshToken = Guid.NewGuid().ToString();
                wantedUser.RerfreshTokenExpiration = DateTime.Now.AddHours(12);

                await _context.SaveChangesAsync();

                return new LoginHelper(DbAnswer.Ok, new JwtSecurityTokenHandler().WriteToken(token).ToString(),
                    wantedUser.RefreshToken);
            }

            return new LoginHelper(DbAnswer.BadPassword);
        }

        public async Task<LoginHelper> UpdateAccessTokenAsync(RefreshTokenDto dto)
        {
            var wantedUser = await _context.User.FirstOrDefaultAsync(e => e.RefreshToken == dto.RefreshToken);
            if (wantedUser != null)
            {
                if (wantedUser.RerfreshTokenExpiration < DateTime.Now)
                    return new LoginHelper(DbAnswer.RefreshTokenIsExpired);

                var token = GetToken();

                wantedUser.RefreshToken = Guid.NewGuid().ToString();
                wantedUser.RerfreshTokenExpiration = DateTime.Now.AddHours(12);

                await _context.SaveChangesAsync();

                return new LoginHelper(DbAnswer.Ok, new JwtSecurityTokenHandler().WriteToken(token).ToString(),
                    wantedUser.RefreshToken);
            }

            return new LoginHelper(DbAnswer.UserNotFound);
        }

        public JwtSecurityToken GetToken()
        {
            var userClaims = new[]
            {
                new Claim(ClaimTypes.Role, "user"),
                new Claim(ClaimTypes.Role, "client")
            };

            SymmetricSecurityKey key;
            key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Secret"]));
            SigningCredentials credentials;
            credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "http://localhost",
                audience: "http://localhost",
                claims: userClaims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: credentials);

            return token;
        }
    }
}