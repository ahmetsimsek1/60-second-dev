using System;
using System.Linq;
using System.Text.Json;

Console.Write("Create a username: ");
string userName = Console.ReadLine();

Console.Write("Create a password: ");
string password = Console.ReadLine();

// Apply password quality checks here...

(byte[] hash, byte[] salt) = Passwords.HashPassword(password);

// Store userName, hash, and salt in database: Hash=BINARY(32) and Salt=BINARY(16)
Database.Write(userName, hash, salt);

Console.WriteLine($@"Storing the following in database:
  Hash={JsonSerializer.Serialize(hash)}
  Salt={JsonSerializer.Serialize(salt)}
");

////////////////////////////////////////////////////////

while (true)
{
    Console.WriteLine();
    Console.WriteLine("Log in:");
    Console.Write("Username: ");
    userName = Console.ReadLine();

    Console.Write("Password: ");
    password = Console.ReadLine();

    (byte[] hashFromDB, byte[] saltFromDB) = Database.GetFromDatabase(userName);
    byte[] hashFromUser = Passwords.HashPassword(password, saltFromDB);
    if (hashFromUser.SequenceEqual(hashFromDB))
        Console.WriteLine("Success!");
    else
        Console.WriteLine("Fail!");
}