using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Model;
using WebApplication4.Repository.CityRepository;

namespace WebApplication4.Controller;


[ApiController]
[Route("[controller]")]
public class CityController:ControllerBase
{
    
    private readonly ICityRepository _cityRepository;
    
    public CityController(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    [HttpGet]
    public List<City> Get()
    {
        return _cityRepository.GetCity();
    }

    [HttpPost]
    public string Add(City city)
    {
        return _cityRepository.AddCity(city);
    }

    [HttpPut("{id}")]
    public string Put(int id, City city)
    {
        return _cityRepository.UpdateCity(id, city);
    }


    [HttpDelete("{id}")]
    public string Delete(int id)
    {
        return _cityRepository.DeleteCity(id);
    }

    [HttpGet("{id}")]
    public City Get(int id)
    {
        return _cityRepository.GetCity(id);
    }
}