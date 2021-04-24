using System;
using System.Security.Cryptography;

Console.WriteLine("Non-secure:");
Random rand = new(); // Create this one time, rather than for each new number

Console.WriteLine("Dangerous:");
for (int i = 0; i < 100; ++i)
{
    // Don't do this - if you are unlucky, you could end up with duplicate values
    Random r = new();
    Console.WriteLine(r.NextDouble());
}

Console.WriteLine("Integers:");
for (int i = 0; i < 10; ++i) { Console.WriteLine(rand.Next()); }
Console.WriteLine("Doubles:");
for (int i = 0; i < 10; ++i) { Console.WriteLine(rand.NextDouble()); }
Console.WriteLine("Byte arrays:");
for (int i = 0; i < 10; ++i)
{
    byte[] b = new byte[10];
    rand.NextBytes(b);
    Console.WriteLine(Convert.ToBase64String(b));
}

Console.WriteLine("Secure:");

Console.WriteLine("Integers:");
for (int i = 0; i < 10; ++i) { Console.WriteLine(RandomNumberGenerator.GetInt32(int.MaxValue)); }
Console.WriteLine("Byte arrays:");
for (int i = 0; i < 10; ++i)
{
    Span<byte> bytes = new byte[10];
    RandomNumberGenerator.Fill(bytes);
    Console.WriteLine(Convert.ToBase64String(bytes));
}
Console.WriteLine("Non-zero bytes:");
using (var rng = RandomNumberGenerator.Create())
{
    Span<byte> bytes = new byte[10];
    rng.GetNonZeroBytes(bytes);
    Console.WriteLine(Convert.ToBase64String(bytes));
}