using System;

static class CustomClass
{
    static Person GetPerson() => new Person(6, "Kelly");

    public static void Go()
    {
        var person = GetPerson();
        Console.WriteLine($"{person.ID}, {person.Name}");
    }
}

class Person
{
    public Person(int id, string name)
    {
        ID = id;
        Name = name;
    }
    public int ID { get; set; }
    public string Name { get; set; }
}