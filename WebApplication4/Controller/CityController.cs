using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Model;
using WebApplication4.Model.DTO.City;
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
    public List<GetCityDto> Get()
    {
        return _cityRepository.GetCity();
    }
    
    
    
    [HttpGet("{id}")]
    public GetCityDto Get(int id)
    {
        return _cityRepository.GetCity(id);
    }

    [HttpPost]
    public string Add(CreateUpdateCityDto city)
    {
        return _cityRepository.AddCity(city);
    }

    [HttpPut("{id}")]
    public string Put(int id, CreateUpdateCityDto city)
    {
        return _cityRepository.UpdateCity(id, city);
    }


    [HttpDelete("{id}")]
    public string Delete(int id)
    {
        return _cityRepository.DeleteCity(id);
    }

}