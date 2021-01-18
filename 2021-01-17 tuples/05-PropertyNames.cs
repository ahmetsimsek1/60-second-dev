using System;

static class PropertyNames
{
    static (int ID, string Name) GetPerson1() => (3, "Pat");

    public static void Go()
    {
        (int someID, string someName) = GetPerson1();
        Console.WriteLine($"{someID}: {someName}");

        // Use the property names from the method
        var person = GetPerson1();
        Console.WriteLine($"{person.ID}: {person.Name}");
    }
}
