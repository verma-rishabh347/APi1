using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Model;

namespace WebApplication4.Repository.ProfileRepository;

public class ProfileRepository: IProfileRepository
{
    private readonly DataContext _context;
    
    public ProfileRepository(DataContext context)
    {
        _context = context;
    }
    
    public List<Profile> GetProfile()
    {
        return _context.Profiles.Include(x=>x.City).ThenInclude(x=>x.States).ThenInclude(x=>x.Country).ToList();
    }
    
    public Profile GetProfile(long id)
    {
        return _context.Profiles.Find(id);
    }
    
    public string PostProfile(Profile profile)
    {
        if (_context.Profiles.Any(x=>x.Phone==profile.Phone || x.Email==profile.Email) )
        {
            return "Acount with same details already exists";
            
        }
        else
        {
            _context.Profiles.Add(profile);
            _context.SaveChanges();
            return "Success";
            
        }
        


    }
    
    public string PutProfile(long id, Profile profile)
    {
        var currentProfile = _context.Profiles.Find(id);
        if (_context.Profiles.Any(x=>(x.Phone==profile.Phone || x.Email==profile.Email)&&id!=currentProfile.Id) )
        {
            if (currentProfile != null)
            {
                _context.Update(profile);
                _context.SaveChanges();
                return "Success";
            }
            else
            {
                return "eomething is wrong";
            }
            
            
            
        }
        else
        {
            return "Email or mobile number is invalid";
        }
        
    }
    
    public string DeleteProfile(long id)
    {
        var currentProfile = _context.Profiles.Find(id);
        if (currentProfile != null)
        {
            _context.Profiles.Remove(currentProfile);
            _context.SaveChanges();
        }
        return "Success";
        
    }
    
    
    
    
    
}