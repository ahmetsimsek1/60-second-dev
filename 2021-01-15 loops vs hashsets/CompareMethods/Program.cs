using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

var sw = new Stopwatch();

Console.WriteLine("Populating array");
Guid[] allItems = File.ReadAllLines("items.txt").Select(Guid.Parse).ToArray();
Console.WriteLine("Populating HashSet");
var allItemsHashSet = new HashSet<Guid>(allItems);

Console.WriteLine("Populating items to find");
// 500 matches, 50 non-matches
Guid[] itemsToFind = File.ReadAllLines("items-to-find.txt")
    .Union(Enumerable.Range(0, 50).Select(x => Guid.NewGuid().ToString()))
    .OrderBy(x => x)
    .Select(Guid.Parse)
    .ToArray();

Console.WriteLine("Working with array");
for (int i = 0; i < 3; ++i)
{
    sw.Reset();
    sw.Start();
    Go(allItems, out int numFound, out int numNotFound);
    sw.Stop();
    Console.WriteLine($"{sw.ElapsedTicks:#,##0} ticks, found={numFound}, not found={numNotFound}");
}

Console.WriteLine("Working with HashSet");
for (int i = 0; i < 3; ++i)
{
    sw.Reset();
    sw.Start();
    Go(allItemsHashSet, out int numFound, out int numNotFound);
    sw.Stop();
    Console.WriteLine($"{sw.ElapsedTicks:#,##0} ticks, found={numFound}, not found={numNotFound}");
}

void Go(IEnumerable<Guid> items, out int numFound, out int numNotFound)
{
    numFound = numNotFound = 0;
    foreach (Guid itemToFind in itemsToFind)
    {
        if (items.Contains(itemToFind))
            ++numFound;
        else
            ++numNotFound;
    }
}