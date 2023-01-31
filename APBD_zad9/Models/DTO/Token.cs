
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_zad9.Models.DTO

{
    public class RefreshTokenDto
    {
        public RefreshTokenDto(string refreshToken) => RefreshToken = refreshToken;

        public string RefreshToken { get; set; }
    }
}