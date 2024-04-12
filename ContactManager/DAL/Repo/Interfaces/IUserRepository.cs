using ContactManager.DAL.Models;

namespace ContactManager.DAL.Repo.Interfaces;

public interface IUserRepository
{
    public Task UploadAsync(List<User> users);
    Task<List<User>> GetAllUsersAsync();
    Task DeleteUserAsync(int id);
    Task UpdateUserAsync(User user);
}