using WebApplication4.Model;
using WebApplication4.Model.DTO.Country;

namespace WebApplication4.Repository.CountryRepository;

public interface ICountryRepository
{
    public Task<List<GetCountryDto>>  GetCountry();
    Task<GetCountryDto>  GetCountry(int id);
    Task<String>  AddCountry(CreateUpdateCountryDto country);
    Task<String> DeleteCountry(int id);

    Task<String> PutCountry(int id, CreateUpdateCountryDto country);

}