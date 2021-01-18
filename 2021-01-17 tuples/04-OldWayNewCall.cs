using System;

static class OldWayNewCall
{
    static Tuple<int, string> GetPersonTheOldWay() => Tuple.Create(2, "Mary");

    public static void Go()
    {
        (int myID, string myName) = GetPersonTheOldWay();
        Console.WriteLine($"{myID}: {myName}");
    }
}