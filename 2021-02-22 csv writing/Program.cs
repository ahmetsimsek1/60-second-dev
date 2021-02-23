using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;

var items = new[]
{
    new Item(1, "Something", DateTime.Now, null, 3.45m, null),
    new Item(2, "Something else\nwith two lines", DateTime.Today, DateTime.Today.AddDays(2), 4.56m, 1),
    new Item(3, "Something \"with\" quotes, and commas", DateTime.Now, null, 5.67m, null)
};

using var writer = new StreamWriter("output.csv");


using var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);

// using var csvWriter = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)
// {
//     NewLine = "\n",
//     HasHeaderRecord = false
// });

await csvWriter.WriteRecordsAsync(items);


//await csvWriter.WriteRecordsAsync(GetRecords());

// static IEnumerable<Item> GetRecords()
// {
//     // DB: open connection, open command, open data reader, yield return each reader record

//     yield return new Item(1, "Something", DateTime.Now, null, 3.45m, null);
//     yield return new Item(2, "Something else\nwith two lines", DateTime.Today, DateTime.Today.AddDays(2), 4.56m, 1);
//     yield return new Item(3, "Something \"with\" quotes, and commas", DateTime.Now, null, 5.67m, null);
// }
