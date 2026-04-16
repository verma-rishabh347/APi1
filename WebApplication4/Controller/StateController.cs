using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Model;
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
    public IActionResult Get()
    {
        return Ok(_istateRepository.GetState());
    }
    
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {

        return Ok(_istateRepository.GetState(id));
        
        
    }
    
    

    [HttpPost]
    public string Add(State state)
    {
        return _istateRepository.AddState(state);
      

    }

    [HttpPut("{id}")]
    public string Update(int id,State state)
    {
        return _istateRepository.UpdateState(id,state);
      

    }

    [HttpDelete("{id}")]
    public string Delete(int id)
    {
        return _istateRepository.DeleteState(id);
       
    }

   
}