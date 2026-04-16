using WebApplication4.Model;

namespace WebApplication4.Repository.ProfileRepository;

public interface IProfileRepository
{
    public List<Profile> GetProfile();

    public Profile GetProfile(long id);

    public void PostProfile(Profile profile);

    public void PutProfile(long id, Profile profile);

    public void DeleteProfile(long id);




}