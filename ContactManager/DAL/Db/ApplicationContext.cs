using ContactManager.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.DAL.Db;

public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }  
}