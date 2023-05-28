using UserMicroservice.DataAccessLayer.Models;

namespace UserMicroservice.DataAccessLayer.Repository
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(int userId);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<int> AddUserAsync(User user);
        Task<bool> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(int userId);
        Task<User> CreateUserAsync(User user); // Add this method
    }
}
