using System;
using System.Globalization;
using System.IO;
using CsvHelper; // https://joshclose.github.io/CsvHelper/

using var reader = new StreamReader("data.csv");
using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

while (csv.Read())
{
    var record = csv.GetRecord<MyRecord>();
    Console.WriteLine(record);
}

/*
foreach (var record in csv.GetRecords<MyRecord>())
{
    Console.WriteLine(record);
}
*/