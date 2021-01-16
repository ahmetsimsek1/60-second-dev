using System.IO;
using System;

using (var writer = new StreamWriter("items.txt"))
{
    for (int i = 0; i < 1000000; ++i) { writer.WriteLine(Guid.NewGuid()); }
}

var allItems = File.ReadAllLines("items.txt");
var rand = new Random();

using (var writer = new StreamWriter("items-to-find.txt"))
{
    for (int i = 0; i < 500; ++i)
    {
        writer.WriteLine(allItems[rand.Next(0, 1000000)]);
    }
}