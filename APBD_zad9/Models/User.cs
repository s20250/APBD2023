
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_zad9.Models {
    public class User
    {
        public User()
        {
        }

        public User(string login, string password, string salt, string refreshToken, DateTime? rerfreshTokenExpiration)
        {
            Login = login;
            Password = password;
            Salt = salt;
            RefreshToken = refreshToken;
            RerfreshTokenExpiration = rerfreshTokenExpiration;
        }

        public int IdUser { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? RerfreshTokenExpiration { get; set; }
    }
}