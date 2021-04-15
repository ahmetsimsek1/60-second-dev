using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

async Task CreateDatabaseAsync()
{
    using var conn = new SqliteConnection("Data Source=sample.db");
    await conn.OpenAsync();
    using var comm = conn.CreateCommand();
    comm.CommandText = @"
        CREATE TABLE Products (
            ProductID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT
            ,ProductName TEXT NOT NULL

            -- Use INTEGER and convert appropriately if you don't
            -- want to deal with floating point numbers
            ,Price REAL NOT NULL 
            ,Logo BLOB NULL
        );";
    await comm.ExecuteNonQueryAsync();
}

if (!File.Exists("sample.db"))
{
    await CreateDatabaseAsync();
}

using var conn = new SqliteConnection("DataSource=sample.db");
await conn.OpenAsync();
using (var comm = conn.CreateCommand())
{
    comm.CommandText = @"
        INSERT INTO Products (ProductName, Price, Logo) 
            VALUES (@Product1, 199.99, NULL)
            ,(@Product2, 1499.99, @Logo2)
            , (@Product3, 999.99, NULL);
    ";
    comm.Parameters.AddRange(new[]
    {
        new SqliteParameter("@Product1", SqliteType.Text) { Value = "TV" },
        new SqliteParameter("@Product2", SqliteType.Text) { Value = "Laptop" },
        new SqliteParameter("@Product3", SqliteType.Text) { Value = "Phone" },
        new SqliteParameter("@Logo2", SqliteType.Blob) { Value = new byte[] { 1, 2, 3, 4 } }
    });
    await comm.ExecuteNonQueryAsync();
}

using (var comm = conn.CreateCommand())
{
    comm.CommandText = "SELECT * FROM Products;";
    using var rdr = await comm.ExecuteReaderAsync();
    while (await rdr.ReadAsync())
    {
        var product = new Product(
            rdr.GetInt64(0),
            rdr.GetString(1),
            rdr.GetDouble(2),
            await rdr.IsDBNullAsync(3) ? default : rdr.GetFieldValue<byte[]>(3)
        );
        Console.WriteLine(product);
    }
}

record Product(long ProductID, string ProductName, double Price, byte[]? Logo)
{
    public override string ToString()
        => $"ProductID={ProductID}, Name={ProductName}, Price={Price}, Logo={Convert.ToBase64String(Logo ?? Array.Empty<byte>())}";
}
