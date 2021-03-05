public record TeamRecord(string Name, int YearFormed);

// Alternate syntaxes:

public record TeamRecord1
{
    public string Name { get; init; }
    public int YearFormed { get; init; }
}

public record TeamRecord2
{
    private readonly string _name;
    private readonly int _yearFormed;

    public TeamRecord2(string name, int yearFormed) => (_name, _yearFormed) = (name, yearFormed);

    public string Name => _name;
    public int YearFormed => _yearFormed;
}

// NOTE: This is not immutable!
public record TeamRecord3
{
    public TeamRecord3(string name, int yearFormed) => (Name, YearFormed) = (name, yearFormed);

    public string Name { get; set; }
    public int YearFormed { get; set; }
}