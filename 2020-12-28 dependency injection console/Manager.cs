using static System.Console;
 
public interface IManager {
    void Go();
}
 
public class Manager: IManager {
    private IRepo _repo;
    public Manager(IRepo repo) => _repo = repo;
 
    void IManager.Go() => WriteLine(_repo.Hello("world"));
}
