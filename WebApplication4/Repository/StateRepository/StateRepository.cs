using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Model;

namespace WebApplication4.Repository.StateRepository;

public class StateRepository:IStateRepository

{
    private readonly DataContext _dataContext;
    
    public StateRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    
    public List<State> GetState()
    {
        return _dataContext.States.Include(x=>x.Country).ToList();
    }

    public State GetState(int id)
    {
        return _dataContext.States.Include(x=>x.Country).SingleOrDefault(s => s.Id ==id);
    }

    public string AddState(State state)
    {
        if (_dataContext.States.Any(x => x.Name == state.Name))
        {
            return "State with same name already exists";
            
        }
        else
        {
            _dataContext.States.Add(state);
            _dataContext.SaveChanges();
            return "State added successfully";
            
        }
        
        
        
    }
    public string UpdateState(int id,State state)
    {
        if (_dataContext.States.Any(x => x.Name == state.Name&&x.Id!=id))
        {
            return "State with same name already exists";
            
        }
        else
        {
            var currentState = _dataContext.States.FirstOrDefault(x => x.Id == id);

            if (currentState != null)
            {
                currentState.Name = state.Name;
                currentState.CountryId = state.CountryId;
                _dataContext.SaveChanges();
            
            }
            _dataContext.SaveChanges();
            return "State updated successfully";
            
        }
        
        
    }

    public string DeleteState(int id)
    {
        var currentState = _dataContext.States.FirstOrDefault(x => x.Id == id);
        if (currentState != null)
        {
            _dataContext.States.Remove(currentState);
            _dataContext.SaveChanges();
            return "State deleted successfully";
        }
        
        return "State not found";
        
    }


        
    
}