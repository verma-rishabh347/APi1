using Microsoft.AspNetCore.Mvc;

using WebApplication4.Model;
using WebApplication4.Repository.ProfileRepository;

namespace WebApplication4.Controller;

[ApiController]
[Route("[controller]")]

public class ProfileController:ControllerBase
{
    private readonly IProfileRepository _profileRepository;

    public ProfileController(IProfileRepository profileRepository)
    {
        _profileRepository = profileRepository;
    }

    [HttpGet]
    public List<Profile> Get()
    {
        return _profileRepository.GetProfile();
    }
    
    [HttpGet("{id}")]
    public Profile Get(long id)
    {
        return _profileRepository.GetProfile(id);
    }



    [HttpPost]
    public void Post(Profile profile)
    {
        _profileRepository.PostProfile(profile);


    }

    [HttpPut("{id}")]
    public void Put(long id, Profile profile)
    {
       _profileRepository.PutProfile(id, profile);
    }

    [HttpDelete("{id}")]
    public void Delete(long id)
    {
        _profileRepository.DeleteProfile(id);
        
    }
    
    

}