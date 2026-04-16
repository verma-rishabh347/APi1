using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebApplication4.Model;

public class Profile
{
    [Key]
    public int Id { get; set; }
    public String FirstName { get; set; }
    public String LastName { get; set; }
    public int Age { get; set; }
    public decimal AnnualIncome { get; set; }
    public DateTime BirthDate { get; set; }
    public bool IsPass { get; set; } 
    public String Password { get; set; }
    public String ConfirmPassword { get; set; }
    public String Email { get; set; }
    public long Phone { get; set; }
    
    [ForeignKey("City")]
    public int CityId { get; set; }
    public City? City { get; set; }
    
    
    
}