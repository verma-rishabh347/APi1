using WebApplication4.Model;

namespace WebApplication4.Repository.StateRepository;

public interface IStateRepository
{
    public List<State> GetState();
    public string AddState(State state);
    public string UpdateState(int id, State state);
    public string DeleteState(int id);
    public State GetState(int id);

}