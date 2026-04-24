using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebApplication4.Model;

public class Profile
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MinLength(4), MaxLength(15)]
    public String FirstName { get; set; }
    public String LastName { get; set; }
    [Required]
    public int Age { get; set; }
    [Required]
    public decimal AnnualIncome { get; set; }
    
    public DateTime BirthDate { get; set; }
    
    public bool IsPass { get; set; } 
    [Required (ErrorMessage = "Password is required")]
    [RegularExpression(@"^\d{8}$")]
    public String Password { get; set; }
    [Compare("Password")]
    public String ConfirmPassword { get; set; }
    [EmailAddress]
    public String Email { get; set; }
    [Phone]
    public long Phone { get; set; }
    
    [ForeignKey("City")]
    public int CityId { get; set; }
    public City City { get; set; }
    
    
    
}