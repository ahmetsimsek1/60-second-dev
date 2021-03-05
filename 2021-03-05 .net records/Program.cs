using System;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

Console.WriteLine();

var t1 = new TeamClass("hello", 123);
var t2 = new TeamClass("hello", 123);

// t1 != t2
Console.WriteLine($"t1 {(t1 == t2 ? "==" : "!=")} t2");

// t1 Not ReferenceEquals t2
Console.WriteLine($"t1 {(object.ReferenceEquals(t1, t2) ? "ReferenceEquals" : "Not ReferenceEquals")} t2");


Console.WriteLine();

var t3 = new TeamRecord("hello", 123);
var t4 = new TeamRecord("hello", 123);

// t3 == t4
Console.WriteLine($"t3 {(t3 == t4 ? "==" : "!=")} t4");

// t3 Not ReferenceEquals t4
Console.WriteLine($"t3 {(object.ReferenceEquals(t3, t4) ? "ReferenceEquals" : "Not ReferenceEquals")} t4");


Console.WriteLine();

// TeamClass
Console.WriteLine(new TeamClass("First Team", 2010));

// TeamRecord { Name = Second Team, YearFormed = 2012 }
Console.WriteLine(new TeamRecord("Second Team", 2012));

Console.WriteLine();

// TheImplementation { Message = Hello, Temperature = 98 }
Console.WriteLine(new TheImplementation("Hello", 98));

ISomething something = new Something();
something.Go();

Console.WriteLine();

var browser = new Browser("Firefox", 123.45m, true);
Console.WriteLine(browser);


// JSON serialization works fine
Console.WriteLine(JsonSerializer.Serialize(browser));

Console.WriteLine();

// XML serialization fails because it doesn't have a default constructor
try
{
    var xmlSerializer = new XmlSerializer(typeof(Browser));
    var writer = new StringWriter();
    xmlSerializer.Serialize(writer, browser);
    Console.WriteLine(writer.ToString());
}
catch{}

Console.WriteLine();


var team = new TeamRecord("Third Team", 2014);
var teamWithDifferentYear = team with { YearFormed = 2015 };
var teamCopy = team with { };

Console.WriteLine();

browser.Deconstruct(out string name, out decimal version, out bool isGood);
Console.WriteLine(name);
Console.WriteLine(version);
Console.WriteLine(isGood);

Console.WriteLine();
