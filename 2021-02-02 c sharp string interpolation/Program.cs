using System;
using static System.Console;

string name = "world";
WriteLine($"Hello {name}");

WriteLine($"Hello {name}, your choices are: {{ A, B, C }}");

WriteLine($"The time is {DateTime.Now:HH:mm}");

string tableName = "Users";
WriteLine(@$"
    SELECT * FROM {tableName}
    WHERE UserID = 1;
");

bool success = true;
WriteLine($"Was it successful? {(success ? "Yes" : "No")}");

var people = new[] {
     new { Name = "Mookie", Age = 49 },
     new { Name = "Shrek", Age = 7 }
};

WriteLine($"{"Name",-12}|{"Age",3}");
foreach (var person in people)
{
    WriteLine($"{person.Name,-12}|{person.Age,3}");
}
