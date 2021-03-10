using System;

public class Person
{
    public string FirstName { get; set; } = "";
    public string? MiddleName { get; set; }
    public string LastName { get; set; } = "";

    // This is dangerous:
    public string FavoriteFood { get; set; } = default!;
}

// OR

public class Person1
{
    public Person1(string firstName, string? middleName, string lastName)
        => (FirstName, MiddleName, LastName) = (firstName, middleName, lastName);

    public string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string LastName { get; set; }
}
