using System;

static class OldTuples
{
    static Tuple<int, string> GetPersonTheOldWay() => Tuple.Create(1, "John");

    public static void Go()
    {
        var oldWay = GetPersonTheOldWay();
        Console.WriteLine($"{oldWay.Item1}: {oldWay.Item2}");
    }
}
