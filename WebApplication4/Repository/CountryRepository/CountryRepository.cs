using WebApplication4.Data;
using WebApplication4.Model;

namespace WebApplication4.Repository.CountryRepository;

public class CountryRepository: ICountryRepository
{
    
    private readonly DataContext  _dataContext;
    
    public CountryRepository(DataContext dataContext)
    {
        _dataContext=dataContext;
    }
    
    public List<Country> GetCountry()
    {
        return _dataContext.Countries.ToList();
    }
    
    public Country? GetCountry(int id)
    {
        return _dataContext.Countries.FirstOrDefault(x=>x.Id==id);
    }
    
    
    public string AddCountry(Country country)
    {
        if (_dataContext.Countries.Any(x=>x.Name==country.Name))
        {
            return ("Name Already Exists");
            


        }
        else if (_dataContext.Countries.Any(x=>x.Code==country.Code))
        {
            return ("Code Already Exists");
        }
        else
        {
            _dataContext.Countries.Add(country);
            _dataContext.SaveChanges();
            return ("Add successful");
            
        }

       
    }
    
    public string DeleteCountry(int id)
    {
        var country = _dataContext.Countries.FirstOrDefault(x => x.Id == id);

        if (country != null)
        {
            _dataContext.Countries.Remove(country);
            _dataContext.SaveChanges();
            return ("Delete successful");
            
        }
        else
        {
            return ("Country Not Exists");
        }
    }
    
    
    public string PutCountry(int id, Country country)
    {
        var currentCountry = _dataContext.Countries.FirstOrDefault(x => x.Id == id);

        if (currentCountry == null)
        {
            return "Country Not Exists";
        }

        bool alreadyExists = _dataContext.Countries.Any(x =>
            x.Id != id &&
            (x.Name == country.Name || x.Code == country.Code));

        if (alreadyExists)
        {
            return "Name or Code Already Exists";
        }

        currentCountry.Name = country.Name;
        currentCountry.Code = country.Code;

        _dataContext.SaveChanges();

        return "Update Successful";
    
    }
    
    
    
    
    
    
    
}