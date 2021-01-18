using System;

Console.WriteLine();
Console.WriteLine($"No Params: {Guid.NewGuid().ToString()}");
Console.WriteLine($"D:         {Guid.NewGuid().ToString("D")}");
Console.WriteLine($"N:         {Guid.NewGuid().ToString("N")}");
Console.WriteLine($"B:         {Guid.NewGuid().ToString("B")}");
Console.WriteLine($"P:         {Guid.NewGuid().ToString("P")}");
Console.WriteLine($"X:         {Guid.NewGuid().ToString("X")}");
Console.WriteLine();

Console.WriteLine($"Empty: {Guid.Empty}");

try { Guid.Parse("511fb6c9-a300-4dc6-9e9d-a6a1a5c8db5f"); }
catch { Console.WriteLine("ERR1"); }
if (!Guid.TryParse("(dc01c0c3-9ec4-4ffe-aab6-ef3fe78dd736)", out _))
    Console.WriteLine("ERR2");
try { Guid.Parse("{0xcaf820fc,0x1204,0x4110,{0x87,0x57,0x4b,0xed,0xe6,0x25,0xd6,0x4b}}"); }
catch { Console.WriteLine("ERR3"); }
try { Guid.ParseExact("511fb6c9-a300-4dc6-9e9d-a6a1a5c8db5f", "N"); }
catch { Console.WriteLine("ERR4"); }
try { Guid.Parse("511FB6C9-A300-4DC6-9E9D-A6A1A5C8DB5F"); }
catch { Console.WriteLine("ERR5"); }
try { Guid.ParseExact("511FB6C9-A300-4DC6-9E9D-A6A1A5C8DB5F", "D"); }
catch { Console.WriteLine("ERR6"); }
try { Guid.Parse("11111111-1111-1111-1111-111111111111"); } // Not v4 but still ok
catch { Console.WriteLine("ERR7"); }

Console.WriteLine();
