using ContactManager.DAL.Db;
using ContactManager.DAL.Models;
using ContactManager.DAL.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.DAL.Repo;

public class UserRepository(ApplicationContext context) : IUserRepository
{
    private readonly ApplicationContext _context = context;
    public async Task UploadAsync(List<User> users)
    {
        await _context.AddRangeAsync(users);
        await _context.SaveChangesAsync();
    }

    public async  Task<List<User>> GetAllUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task DeleteUserAsync(int id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }

    public async  Task UpdateUserAsync(User user)
    {
         _context.Users.Update(user);
         await _context.SaveChangesAsync();
    }
}