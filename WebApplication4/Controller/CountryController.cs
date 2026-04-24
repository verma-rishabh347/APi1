using Microsoft.AspNetCore.Mvc;
using WebApplication4.Data;
using WebApplication4.Model;
using WebApplication4.Model.DTO.Country;
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
    public async Task<List<GetCountryDto>>  Get()
    {
        return await _contryRepository.GetCountry();
    }
    [HttpGet("{id}")]
    
    public async Task<GetCountryDto> Get(int id)
    {
        return await _contryRepository.GetCountry(id);
    }

    [HttpPost]
    public async Task<String> Add(CreateUpdateCountryDto country)
    {
        return await _contryRepository.AddCountry(country);
    }


    [HttpDelete("{id}")]
    public async  Task<String> Delete(int id)
    {
        return await _contryRepository.DeleteCountry(id);
        
    }


    [HttpPut("{id}")]
    public async Task<String> Put(int id, CreateUpdateCountryDto country)
    {
        return await _contryRepository.PutCountry(id, country);
    }
    
}