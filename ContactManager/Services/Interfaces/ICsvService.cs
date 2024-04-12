using System.Globalization;
using ContactManager.DAL.Models;
using CsvHelper;

namespace ContactManager.Services.Interfaces;

public interface ICsvService
{
    public Task<List<User>> Deserialize(IFormFile file);
}