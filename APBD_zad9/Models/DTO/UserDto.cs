

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_zad9.Models.DTO
{
    public class UserDto
    {
        public UserDto(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public string Login { get; set; }
        public string Password { get; set; }
    }
}