using System;

static class OutParameters
{
    static void GetPerson(out int id, out string name)
    {
        id = 5;
        name = "Bill";
    }
    public static void Go()
    {
        GetPerson(out int id, out string name);
        Console.WriteLine($"{id}: {name}");
    }
}
