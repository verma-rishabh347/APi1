using WebApplication4.Model;

namespace WebApplication4.Repository.CityRepository;

public interface ICityRepository
{
    public List<City> GetCity();
    public City GetCity(int id);
    public string AddCity(City city);
    public string UpdateCity(int id, City city);
    public string DeleteCity(int id);

}