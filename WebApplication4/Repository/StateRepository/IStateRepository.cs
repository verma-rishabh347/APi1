using WebApplication4.Model;
using WebApplication4.Model.DTO.State;

namespace WebApplication4.Repository.StateRepository;

public interface IStateRepository
{
    public List<GetStateDto> GetState();
    public GetStateDto GetState(int id);
    public string AddState(CreateUpdateStateDto state);
    public string UpdateState(int id, CreateUpdateStateDto state);
    public string DeleteState(int id);

}