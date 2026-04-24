using Microsoft.EntityFrameworkCore;
using WebApplication4.Model;

namespace WebApplication4.Data;

public class DataContext:DbContext
{

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }
    
   public DbSet<Country> Countries { get; set; }
   public DbSet<State> States { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Profile> Profiles { get; set; }
}