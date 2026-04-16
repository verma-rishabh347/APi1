using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Model;

public class Country
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    
}