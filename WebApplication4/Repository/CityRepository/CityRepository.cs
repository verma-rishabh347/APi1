using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Model;

namespace WebApplication4.Repository.CityRepository;

public class CityRepository:ICityRepository
{
    private readonly DataContext _dataContext;
    
    public CityRepository(DataContext context)
    {
        _dataContext = context;
    }

    public List<City> GetCity()
    {
        return _dataContext.Cities.Include(x=>x.States).ThenInclude(x=>x.Country).ToList();
        
    }

    public City GetCity(int id)
    {
        return _dataContext.Cities.Include(x=>x.States).ThenInclude(x=>x.Country).FirstOrDefault(x => x.Id == id);
        
    }

    public string AddCity(City city)
    {
        if (_dataContext.Cities.Any(x => x.Name == city.Name))
        {
            return " City with the same name already exists ";

        }
        else if(_dataContext.Cities.Any(x => x.Pincode == city.Pincode))
        {
            return " City with the same pincode already exists ";
            
        }
        else
        {
            _dataContext.Cities.Add(city);
            _dataContext.SaveChanges();
            return "City Added Successfully";
            
        }
        
       
        
    }

    public string UpdateCity(int id, City city)
    {
        if (_dataContext.Cities.Any(x => x.Id != id && (x.Name == city.Name ||x.Pincode == city.Pincode)))
        {
            return " City with the same name or pincode already exists ";
            
        }
        else
        {
            var currentcity=_dataContext.Cities.Find(id);
            if (currentcity != null)
            {
                currentcity.Name = city.Name;
                currentcity.Pincode = city.Pincode;
                _dataContext.SaveChanges();
                return "City Updated successfully";
            }
            else
            {
                return "City not updated successfully";
            }
            
            
        }
        
        
    }

    public string DeleteCity(int id)
    {
        var currentcity=_dataContext.Cities.Find(id);
        if (currentcity != null)
        {
            _dataContext.Cities.Remove(currentcity);
            _dataContext.SaveChanges();
            return "City Deleted successfully";
        }
        return "City not Deleted Successfully";
        
    }
    
    
}