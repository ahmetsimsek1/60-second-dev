using System.Collections.Generic;
using Newtonsoft.Json;
using static System.Console;

var people = new List<Person> {
    new Person(1, "John", "Doe"),
    new Person(2, "Jane", "Smith")
};

string json = JsonConvert.SerializeObject(people);
WriteLine($"\n{json}\n");

people = JsonConvert.DeserializeObject<List<Person>>(json);

WriteLine("From JSON:");
people.ForEach(WriteLine);
WriteLine();
