using Microsoft.AspNetCore.Mvc;

using WebApplication4.Model;
using WebApplication4.Model.DTO.Profile;
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
    public List<GetProfileDto> Get()
    {
        return _profileRepository.GetProfile();
    }
    
    [HttpGet("{id}")]
    public GetProfileDto Get(int id)
    {
        return _profileRepository.GetProfile(id);
    }



    [HttpPost]
    public string Post(PutpostProfileDto profile)
    {
        return _profileRepository.PostProfile(profile);


    }

    [HttpPut("{id}")]
    public string Put(long id, PutpostProfileDto profile)
    {
       return _profileRepository.PutProfile(id, profile);
    }

    [HttpDelete("{id}")]
    public string Delete(long id)
    {
        return _profileRepository.DeleteProfile(id);
        
    }
    
    

}