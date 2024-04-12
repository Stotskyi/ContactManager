using System.Globalization;
using ContactManager.DAL.Models;
using ContactManager.Services.Interfaces;
using CsvHelper;

namespace ContactManager.Services;

public class CsvService : ICsvService
{
    public async Task<List<User>> Deserialize(IFormFile file)
    {
        using var reader = new StreamReader(file.OpenReadStream());
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        var records = csv.GetRecords<User>().ToList();
        return await Task.FromResult(records);
    }
}