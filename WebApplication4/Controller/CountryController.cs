using Microsoft.AspNetCore.Mvc;
using WebApplication4.Data;
using WebApplication4.Model;
using WebApplication4.Repository.CountryRepository;

namespace WebApplication4.Controller;





[ApiController]
[Route("[controller]")]
public class CountryController:ControllerBase
{
    private readonly ICountryRepository _contryRepository;
    

    public CountryController(ICountryRepository contryRepository)
    {
        _contryRepository=contryRepository;
    }
    
    [HttpGet]
    public List<Country> Get()
    {
        return _contryRepository.GetCountry().ToList();
    }

    [HttpPost]
    public String Add(Country country)
    {
        return _contryRepository.AddCountry(country);
    }

    [HttpGet("{id}")]
    
    public Country get(int id)
    {
        return _contryRepository.GetCountry(id);
    }

    [HttpDelete("{id}")]
    public string Delete(int id)
    {
        return _contryRepository.DeleteCountry(id);
        
    }


    [HttpPut("{id}")]
    public string Put(int id, Country country)
    {
        return _contryRepository.PutCountry(id, country);
    }
    
}