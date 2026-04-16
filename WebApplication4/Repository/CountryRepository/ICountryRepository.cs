using WebApplication4.Model;
using WebApplication4.Model.DTO.Country;

namespace WebApplication4.Repository.CountryRepository;

public interface ICountryRepository
{
    public List<GetCountryDto> GetCountry();
    public GetCountryDto GetCountry(int id);
    public String AddCountry(CreateUpdateCountryDto country);
    public String DeleteCountry(int id);

    public String PutCountry(int id, CreateUpdateCountryDto country);

}