using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Model;
using WebApplication4.Model.DTO.State;

namespace WebApplication4.Repository.StateRepository;

public class StateRepository:IStateRepository

{
    private readonly DataContext _dataContext;
    
    public StateRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    
    public List<GetStateDto> GetState()
    {
        return _dataContext.States.Include(x=>x.Country).Select(x=>new GetStateDto{Id = x.Id,Name = x.Name,CountryId = x.CountryId}).ToList();
    }

    public GetStateDto GetState(int id)
    {
        State state = _dataContext.States.SingleOrDefault(s => s.Id ==id);
        GetStateDto result = new GetStateDto{Id = state.Id,Name = state.Name,CountryId = state.CountryId};
        return result;
    }

    public string AddState(CreateUpdateStateDto state)
    {
        if (_dataContext.States.Any(x => x.Name == state.Name))
        {
            return "State with same name already exists";
            
        }
        else
        {
            var newState = new State{Name = state.Name,CountryId = state.CountryId,};
            _dataContext.States.Add(newState);
            _dataContext.SaveChanges();
            return "State added successfully";
            
        }
        
        
        
    }
    public string UpdateState(int id,CreateUpdateStateDto state)
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
                return "State updated successfully";
            
            }
            else
            {
                return "State not found";
            }
   
            
            
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