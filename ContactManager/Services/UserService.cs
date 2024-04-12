using ContactManager.DAL.Models;
using ContactManager.DAL.Repo;
using ContactManager.DAL.Repo.Interfaces;
using ContactManager.Services.Interfaces;

namespace ContactManager.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task UploadAsync(List<User> users)
    { 
        await _userRepository.UploadAsync(users);
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        return await _userRepository.GetAllUsersAsync();
    }

    public async Task DeleteUserAsync(int id)
    {
        await _userRepository.DeleteUserAsync(id);
    }

    public async Task UpdateUserAsync(User user)
    {
        await _userRepository.UpdateUserAsync(user);
    }
}