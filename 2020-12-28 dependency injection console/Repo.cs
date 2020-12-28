public interface IRepo {
    string Hello(string name);
}
 
public class Repo : IRepo {
    string IRepo.Hello(string name) => $"Hello {name}";
}