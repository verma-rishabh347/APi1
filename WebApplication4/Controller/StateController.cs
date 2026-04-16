using Microsoft.AspNetCore.Mvc;
using WebApplication4.Model;
using WebApplication4.Model.DTO.State;
using WebApplication4.Repository.StateRepository;

namespace WebApplication4.Controller;


[ApiController]
[Route("[controller]")]
public class StateController:ControllerBase
{
    private readonly IStateRepository _istateRepository;

    

    public StateController(IStateRepository istateRepository)
    {
        _istateRepository = istateRepository;
    }

    [HttpGet]
    public List<GetStateDto> Get()
    {
        return _istateRepository.GetState();
    }
    
    [HttpGet("{id}")]
    public GetStateDto Get(int id)
    {

        return _istateRepository.GetState(id);
        
        
    }
    
    

    [HttpPost]
    public string Add(CreateUpdateStateDto state)
    {
        return _istateRepository.AddState(state);
      

    }

    [HttpPut("{id}")]
    public string Update(int id,CreateUpdateStateDto state)
    {
        return _istateRepository.UpdateState(id,state);
      

    }

    [HttpDelete("{id}")]
    public string Delete(int id)
    {
        return _istateRepository.DeleteState(id);
       
    }

   
}