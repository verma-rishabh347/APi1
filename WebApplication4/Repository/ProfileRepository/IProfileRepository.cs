using WebApplication4.Model;
using WebApplication4.Model.DTO.Profile;

namespace WebApplication4.Repository.ProfileRepository;

public interface IProfileRepository
{
    public List<GetProfileDto> GetProfile();

    public GetProfileDto GetProfile(int id);

    public string PostProfile(PutpostProfileDto profile);

    public string PutProfile(long id, PutpostProfileDto profile);

    public string DeleteProfile(long id);




}