using System;
using System.IO;

foreach (string arg in args)
{
    Console.WriteLine($"{new FileInfo(arg).Name}: {new FileInfo(arg).Length:#,##0} bytes");
}

Console.WriteLine("Press ENTER to exit");
Console.ReadLine();
