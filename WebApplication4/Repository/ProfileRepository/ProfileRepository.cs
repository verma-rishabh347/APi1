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
    
    public void PostProfile(Profile profile)
    {
        _context.Profiles.Add(profile);
        _context.SaveChanges();


    }
    
    public void PutProfile(long id, Profile profile)
    {
        var currentProfile = _context.Profiles.Find(id);
        if (currentProfile != null)
        {
            _context.Update(profile);
            _context.SaveChanges();
        }
    }
    
    public void DeleteProfile(long id)
    {
        var currentProfile = _context.Profiles.Find(id);
        if (currentProfile != null)
        {
            _context.Profiles.Remove(currentProfile);
            _context.SaveChanges();
        }
        
    }
    
    
    
    
    
}