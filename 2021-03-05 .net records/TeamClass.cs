public class TeamClass
{
    private readonly string _name;
    private readonly int _yearFormed;

    public TeamClass(string name, int yearFormed)
        => (_name, _yearFormed) = (name, yearFormed);

    public string Name => _name;
    public int YearFormed => _yearFormed;
}
