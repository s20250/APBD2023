
using System.Threading.Tasks;
using APBD_zad9.Models.DTO;
using APBD_zad9.Models;

namespace APBD_zad9.Services
{
    public interface IAccountsDbRepository
    {
        public Task<DbAnswer> RegisterAsync(UserDto dto);
        public Task<LoginHelper> LoginAsync(UserDto dto);
        public Task<LoginHelper> UpdateAccessTokenAsync(RefreshTokenDto dto);
    }
}