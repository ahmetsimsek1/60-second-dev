using System;

var person = new Person
{
    FirstName = "John",
    LastName = "Adams"
};

Console.WriteLine(person.MiddleName);

// Have to do a null-check or null conditional
Console.WriteLine(person.MiddleName?.Length);

// This line won't compile
Console.WriteLine(person.MiddleName.Length);

// This will compile, but could result in NullReferenceException:
Console.WriteLine(person.MiddleName!.Length);

// This one was set to null in the constructor, so we better
// hope that someone set it to non-null before this runs:
Console.WriteLine(person.FavoriteFood.Length);

// Guaranteed to not be null (unless you specifically
// set it to null! - which you generally should never do)
Console.WriteLine(person.FirstName.Length);