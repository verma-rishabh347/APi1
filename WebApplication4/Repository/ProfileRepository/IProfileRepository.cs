using WebApplication4.Model;

namespace WebApplication4.Repository.ProfileRepository;

public interface IProfileRepository
{
    public List<Profile> GetProfile();

    public Profile GetProfile(long id);

    public string PostProfile(Profile profile);

    public string PutProfile(long id, Profile profile);

    public string DeleteProfile(long id);




}