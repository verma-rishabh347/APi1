using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4.Model;

public class City
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public int Pincode { get; set; }
    [ForeignKey("States")]
    public int StateId { get; set; }
    public State? States { get; set; }
    
    
    
    
}
