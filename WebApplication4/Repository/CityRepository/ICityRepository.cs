using WebApplication4.Model;
using WebApplication4.Model.DTO.City;

namespace WebApplication4.Repository.CityRepository;

public interface ICityRepository
{
    public List<GetCityDto> GetCity();
    public GetCityDto GetCity(int id);
    public string AddCity(CreateUpdateCityDto city);
    public string UpdateCity(int id, CreateUpdateCityDto city);
    public string DeleteCity(int id);

}