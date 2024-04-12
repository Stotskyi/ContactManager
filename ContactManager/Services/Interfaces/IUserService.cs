using ContactManager.DAL.Models;

namespace ContactManager.Services.Interfaces;

public interface IUserService
{
    public Task UploadAsync(List<User> users);
    Task<List<User>> GetAllUsersAsync();
    Task DeleteUserAsync(int id);
    Task UpdateUserAsync(User user);
}