using System.ComponentModel.DataAnnotations.Schema;
using CsvHelper.Configuration.Attributes;

namespace ContactManager.DAL.Models;

public class User
{
    [Ignore]
    public int Id { get; set; }
    
    [Index(0)]
    public string Name { get; set; } = String.Empty;
    
    [Index(1)]
    public DateOnly DateOfBirth { get; set; }
    
    [Index(2)]
    public bool Married { get; set; }
    
    [Index(3)]
    public string Phone { get; set; }

    [Index(4)]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Salary { get; set; }
    
}