using UserMicroservice.BusinessLayer.ModelDto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UserMicroservice.BusinessLayer.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetUserByIdAsync(int id);
        Task<UserDto> CreateUserAsync(UserDto userDto);
        Task<bool> UpdateUserAsync(UserDto userDto);
        Task<bool> DeleteUserAsync(int id);
    }
}
