using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Console;

var cities = new HashSet<string>();
using var reader = new StreamReader("data.txt");
string line;
while ((line = reader.ReadLine()) != null) 
{
    string[] fields = line.Split('\t');
    string city = fields[4];
    cities.Add(city);
}

WriteLine(string.Join(", ", cities.OrderBy(x => x)));