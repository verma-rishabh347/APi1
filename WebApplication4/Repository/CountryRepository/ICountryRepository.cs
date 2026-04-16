using WebApplication4.Model;

namespace WebApplication4.Repository.CountryRepository;

public interface ICountryRepository
{
    public List<Country> GetCountry();
    public Country GetCountry(int id);
    public String AddCountry(Country country);
    public String DeleteCountry(int id);

    public String PutCountry(int id, Country country);

}