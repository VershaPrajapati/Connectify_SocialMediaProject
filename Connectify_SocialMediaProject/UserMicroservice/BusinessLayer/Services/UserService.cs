using UserMicroservice.BusinessLayer.ModelDto;
using UserMicroservice.DataAccessLayer.Models;
using UserMicroservice.DataAccessLayer.Repository;

namespace UserMicroservice.BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            // Perform any necessary mapping/conversion to UserDto here
            return (IEnumerable<UserDto>)users;
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            // Perform the mapping/conversion from User to UserDto here
            var userDto = new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Username = user.Username,
                Password = user.Password
            };
            return userDto;
        }


        public async Task<UserDto> CreateUserAsync(UserDto userDto)
        {
            var user = new User
            {
                // Perform any necessary mapping/conversion from UserDto to User here
                // Example: Name = userDto.Name, Email = userDto.Email, etc.
            };

            var createdUser = await _userRepository.CreateUserAsync(user); // Updated method call
                                                                           // Perform any necessary mapping/conversion to UserDto here
            var createdUserDto = new UserDto
            {
                Id = createdUser.Id,
                Name = createdUser.Name,
                Email = createdUser.Email,
                Username = createdUser.Username,
                Password = createdUser.Password
            };
            return createdUserDto;
        }


        public async Task<bool> UpdateUserAsync(UserDto userDto)
        {
            var existingUser = await _userRepository.GetUserByIdAsync(userDto.Id);

            if (existingUser == null)
                return false;

            // Perform any necessary mapping/conversion from UserDto to User here
            // Example: existingUser.Name = userDto.Name, existingUser.Email = userDto.Email, etc.

            return await _userRepository.UpdateUserAsync(existingUser);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var existingUser = await _userRepository.GetUserByIdAsync(id);

            if (existingUser == null)
                return false;

            return await _userRepository.DeleteUserAsync(existingUser.Id);
        }
    }
}
