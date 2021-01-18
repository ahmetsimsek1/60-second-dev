using System;

static class NoPropertyNames
{
    static (int, string) GetPersonWithoutPropertyNames() => (4, "Pep");

    public static void Go()
    {
        var crappyWay = GetPersonWithoutPropertyNames();
        Console.WriteLine($"{crappyWay.Item1}: {crappyWay.Item2}");

        (int id, string name) = GetPersonWithoutPropertyNames();
        Console.WriteLine($"{id}: {name}");
    }
}
