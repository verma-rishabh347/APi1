using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Model;
using WebApplication4.Model.DTO.Country;

namespace WebApplication4.Repository.CountryRepository;

public class CountryRepository: ICountryRepository
{
    
    private readonly DataContext  _dataContext;
    
    public CountryRepository(DataContext dataContext)
    {
        _dataContext=dataContext;
    }
    
    public async Task<List<GetCountryDto>>  GetCountry()
    {
        
        return await _dataContext.Countries.Select(x=>new GetCountryDto{Name = x.Name,Code = x.Code,Id = x.Id}).ToListAsync();
    }
    
    public async Task<GetCountryDto>  GetCountry(int id)
    {
        
        return await _dataContext.Countries.Where(x=>x.Id==id).Select(x=> new GetCountryDto{Name = x.Name,Code = x.Code,Id = x.Id}).FirstOrDefaultAsync();
    }
    
    
    public async Task<string>  AddCountry(CreateUpdateCountryDto country)
    {
        if (await _dataContext.Countries.AnyAsync(x=>x.Name==country.Name))
        {
            return ("Name Already Exists");
            


        }
        else if ( await _dataContext.Countries.AnyAsync(x=>x.Code==country.Code))
        {
            return  ("Code Already Exists");
        }
        else
        {
            var newCountry = new Country{Name =  country.Name, Code = country.Code};
            
            await _dataContext.Countries.AddAsync(newCountry);
            await _dataContext.SaveChangesAsync();
            return ("Add successful");
            
        }

       
    }
    
    public async Task<string> DeleteCountry(int id)
    {
        var country = await _dataContext.Countries.FirstOrDefaultAsync(x => x.Id == id);

        if (country != null)
        {
            _dataContext.Countries.Remove(country);
             await _dataContext.SaveChangesAsync();
            return ("Delete successful");
            
        }
        else
        {
            return ("Country Not Exists");
        }
    }
    
    
    public async Task<string> PutCountry(int id, CreateUpdateCountryDto country)
    {
        var currentCountry = await _dataContext.Countries.FirstOrDefaultAsync(x => x.Id == id);

        if (currentCountry == null)
        {
            return "Country Not Exists";
        }

        bool alreadyExists = await _dataContext.Countries.AnyAsync(x =>
            x.Id != id &&
            (x.Name == country.Name || x.Code == country.Code));

        if (alreadyExists)
        {
            return "Name or Code Already Exists";
        }

        currentCountry.Name = country.Name;
        currentCountry.Code = country.Code;

        await _dataContext.SaveChangesAsync();

        return "Update Successful";
    
    }
    
    
    
    
    
    
    
}