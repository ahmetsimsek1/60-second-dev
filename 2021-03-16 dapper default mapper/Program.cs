using System;
using System.Data;
using Dapper;
using Microsoft.Data.Sqlite;

await DbPreparer.PrepareDatabaseAsync();

using var conn = new SqliteConnection("Data Source=sample.db");
await conn.OpenAsync();

// 1: Simple
Console.WriteLine();
var appliances = await conn.QueryAsync<Appliance>(@"
    SELECT ApplianceID, ApplianceType, Price, Picture
    FROM Appliances
");

foreach (var appliance in appliances)
{
    Console.WriteLine(appliance);
}

// 2: Dapper parameters
Console.WriteLine();
appliances = await conn.QueryAsync<Appliance>(@"
    SELECT ApplianceID, ApplianceType, Price, Picture
    FROM Appliances
    WHERE ApplianceType = @ApplianceType
", new { ApplianceType = "Dryer" });

foreach (var appliance in appliances)
{
    Console.WriteLine(appliance);
}

// 3: DynamicParameters
Console.WriteLine();
var parms = new DynamicParameters();
parms.Add("@Price", 1000);
appliances = await conn.QueryAsync<Appliance>(@"
    SELECT ApplianceID, ApplianceType, Price, Picture
    FROM Appliances
    WHERE Price > @Price
", parms);

foreach (var appliance in appliances)
{
    Console.WriteLine(appliance);
}

Console.WriteLine();

// By default, strings are Unicode variable length (NVARCHAR in SQL Server)
// To do NVARCHAR(50), set your value to new DbString { Value = "Hello", Length = 50 }
// To do NCHAR(50), set your value to new DbString { Value = "Hello", Length = 50, IsFixedLength = true }
// To do VARCHAR(50), set your value to new DbString { Value = "Hello", Length = 50, IsAnsi = true }
// To do CHAR(50), set your value to new DbString { Value = "Hello", Length = 50, IsFixedLength = true, IsAnsi = true }

// To do decimals with a particular precision and scale, use DynamicParameters instead of anonymous types
