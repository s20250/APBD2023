using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_zad9.Models
{
    public enum DbAnswer
    {
        Ok = 200,
        PasswordLengthIsNotProper,
        UserIsAlreadyRegistered,
        BadPassword,
        UserNotFound,
        RefreshTokenIsExpired
    }
}