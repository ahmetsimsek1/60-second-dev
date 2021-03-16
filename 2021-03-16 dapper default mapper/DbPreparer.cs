using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

static class DbPreparer
{
    private static Random _random = new();
    public static async Task PrepareDatabaseAsync()
    {
        if (File.Exists("sample.db"))
        {
            File.Delete("sample.db");
        }

        using SqliteConnection conn = new("Data Source=sample.db");
        await conn.OpenAsync();
        using (var comm = conn.CreateCommand())
        {
            comm.CommandText = @"
                CREATE TABLE Appliances (
                    ApplianceID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
                    ,ApplianceType TEXT NOT NULL
                    ,Price REAL NOT NULL
                    ,Picture BLOB NULL
                );
            ";
            await comm.ExecuteNonQueryAsync();
        }
        foreach (string appType in new[] { "Fridge", "Washer", "Dryer", "Oven" })
        {
            using (var comm = conn.CreateCommand())
            {
                comm.CommandText = @"
                    INSERT INTO Appliances (ApplianceType, Price, Picture)
                    VALUES (@ApplianceType, @Price, @Picture);
                ";
                comm.Parameters.AddWithValue("@ApplianceType", appType).SqliteType = SqliteType.Text;
                comm.Parameters.AddWithValue("@Price", Math.Round(_random.NextDouble() * 1000 + 500, 2)).SqliteType = SqliteType.Real;
                comm.Parameters.AddWithValue("@Picture", GetPicture() ?? (object)DBNull.Value).SqliteType = SqliteType.Blob;

                await comm.ExecuteNonQueryAsync();
            }
        }
    }
    private static byte[]? GetPicture()
    {
        if (_random.Next(2) == 0)
        {
            return default;
        }
        byte[] result = new byte[10000];
        _random.NextBytes(result);
        return result;
    }
}