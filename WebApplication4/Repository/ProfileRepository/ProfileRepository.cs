using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Model;
using WebApplication4.Model.DTO.Profile;

namespace WebApplication4.Repository.ProfileRepository;

public class ProfileRepository: IProfileRepository
{
    private readonly DataContext _context;
    
    public ProfileRepository(DataContext context)
    {
        _context = context;
    }
    
    public List<GetProfileDto> GetProfile()
    {
           var profile= _context.Profiles.Select(x=>new GetProfileDto{Id = x.Id,Email = x.Email,FirstName = x.FirstName,LastName = x.LastName,Phone = x.Phone,CityId = x.CityId});
        return profile.ToList();
        
    }
    
    public GetProfileDto GetProfile(int id)
    {
        var profile = _context.Profiles.Find(id);
        
        var result = new GetProfileDto
        {
            Id = profile.Id,FirstName = profile.FirstName,LastName = profile.LastName,Phone = profile.Phone,CityId = profile.CityId
        };
        return result;
    }
    
    public string PostProfile(PutpostProfileDto profile)
    {
        if (_context.Profiles.Any(x=>x.Phone==profile.Phone || x.Email==profile.Email) )
        {
            return "Acount with same details already exists";
        }
        else
        {
            var result=new Profile{Id = profile.Id,FirstName = profile.FirstName,LastName = profile.LastName,Phone = profile.Phone,CityId = profile.CityId,Email =  profile.Email,Age =  profile.Age,IsPass = profile.IsPass,Password =  profile.Password,ConfirmPassword =  profile.ConfirmPassword,BirthDate =  profile.BirthDate,AnnualIncome = profile.AnnualIncome };
            _context.Profiles.Add(result);
            _context.SaveChanges();
            return "Success";
        }
        


    }
    public string PutProfile(long id, PutpostProfileDto profile)
    {
        var currentProfile = _context.Profiles.Find(id);
     
        if (_context.Profiles.Any(x=>(x.Phone==profile.Phone || x.Email==profile.Email)&&x.Id!=id) )
        {
            return "Email or mobile number is invalid";
        }
        else
        {
            if (currentProfile != null)
            {
                if (profile.Password!=profile.ConfirmPassword)
                {
                    return "password and confirm password is differnent";
                }
                currentProfile.FirstName = profile.FirstName;
                currentProfile.LastName = profile.LastName;
                currentProfile.Email = profile.Email;
                currentProfile.Phone = profile.Phone;
                currentProfile.CityId = profile.CityId;
                currentProfile.Password = profile.Password;
                currentProfile.ConfirmPassword = profile.ConfirmPassword;
                currentProfile.Age = profile.Age;
                currentProfile.BirthDate = profile.BirthDate;
                currentProfile.AnnualIncome = profile.AnnualIncome;
                currentProfile.IsPass = profile.IsPass;
                
                _context.Update(currentProfile);
                _context.SaveChanges();
                return "Success";
            }
            else
            {
                return "eomething is wrong";
            }
        }
        
    }
    
    public string DeleteProfile(long id)
    {
        var currentProfile = _context.Profiles.Find(id);
        if (currentProfile != null)
        {
            _context.Profiles.Remove(currentProfile);
            _context.SaveChanges();
            return "Success";
        }
        else
        {
            return "something is wrong";
        }
    }
    
}