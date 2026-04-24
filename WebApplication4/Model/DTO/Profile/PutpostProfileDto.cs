namespace WebApplication4.Model.DTO.Profile;

public class PutpostProfileDto
{
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
    public int CityId { get; set; }
}