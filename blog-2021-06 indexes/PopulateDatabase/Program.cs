using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using System.Data;
using System;
using Faker;
using static System.Console;

const int NUM_TEAMS = 5_500;
const int NUM_SCORES = 20_000_000;
const int NUM_CUSTOMERS = 1_000_000;

const string TEAMS_TABLE_NAME = "dbo.Teams";
const string SCORES_TABLE_NAME = "dbo.Scores";
const string CUSTOMERS_TABLE_NAME = "dbo.Customers";

IConfiguration config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

string connectionString = config.GetConnectionString("IndexSandbox");

Random rand = new();

await ClearTableAsync(SCORES_TABLE_NAME, TEAMS_TABLE_NAME, CUSTOMERS_TABLE_NAME);
await ResetIdentityAsync(SCORES_TABLE_NAME, TEAMS_TABLE_NAME, CUSTOMERS_TABLE_NAME);

await PopulateTeamsAsync();
await PopulateScoresAsync();
await PopulateCustomersAsync();

async Task PopulateTeamsAsync()
{
    Write("Populating Teams...");
    const string TABLE_NAME = "dbo.Teams";

    DataTable dataTable = new();
    dataTable.Columns.Add("TeamName", typeof(string));

    for (int i = 0; i < NUM_TEAMS; ++i)
    {
        var row = dataTable.NewRow();
        row["TeamName"] = Company.Name().MaxLength(100);
        dataTable.Rows.Add(row);
    }

    await BulkInsertAsync(TABLE_NAME, dataTable);
    WriteLine("Done");
}

async Task PopulateScoresAsync()
{
    Write("Populating Scores...");
    const int NUM_PER_ITERATION = 20_000;
    const int NUM_ITERATIONS = NUM_SCORES / NUM_PER_ITERATION;

    const string TABLE_NAME = "dbo.Scores";

    DataTable dataTable = new();
    dataTable.Columns.Add("Team1ID", typeof(int));
    dataTable.Columns.Add("Team2ID", typeof(int));
    dataTable.Columns.Add("Team1Score", typeof(int));
    dataTable.Columns.Add("Team2Score", typeof(int));
    dataTable.Columns.Add("GameDate", typeof(DateTime));

    DataRow CreateRandomRow()
    {
        int team1ID = rand.Next(0, NUM_TEAMS);
        int team2ID;
        do
        {
            team2ID = rand.Next(0, NUM_TEAMS);
        } while (team2ID == team1ID);
        int team1Score = rand.Next(0, 150);
        int team2Score = rand.Next(0, 150);
        DateTime gameDate = DateTime.Now.AddSeconds(-1 * rand.Next(0, (int)TimeSpan.FromDays(2000).TotalSeconds));

        var row = dataTable.NewRow();
        row["Team1ID"] = team1ID;
        row["Team2ID"] = team2ID;
        row["Team1Score"] = team1Score;
        row["Team2Score"] = team2Score;
        row["GameDate"] = gameDate;

        return row;
    }

    for (int i = 0; i < NUM_ITERATIONS; ++i)
    {
        if (i % 10 == 0) { WritePercentComplete(i, NUM_ITERATIONS); }
        
        dataTable.Rows.Clear();
        for (int j = 0; j < NUM_PER_ITERATION; ++j)
        {
            dataTable.Rows.Add(CreateRandomRow());
        }

        await BulkInsertAsync(TABLE_NAME, dataTable);
    }

    WriteLine("DONE");
}

async Task PopulateCustomersAsync()
{
    Write("Populating Customers...");
    const int NUM_PER_ITERATION = 20_000;
    const int NUM_ITERATIONS = NUM_CUSTOMERS / NUM_PER_ITERATION;

    const string TABLE_NAME = "dbo.Customers";

    DataTable dataTable = new();
    dataTable.Columns.Add("IsActive", typeof(bool));
    dataTable.Columns.Add("FullName", typeof(string));
    dataTable.Columns.Add("LastLoginDate", typeof(DateTime));

    DataRow CreateRandomRow()
    {
        DateTime lastLoginDate = DateTime.Now.AddSeconds(-1 * rand.Next(0, (int)TimeSpan.FromDays(2000).TotalSeconds));
        bool isActive = rand.Next(0, 2) == 1;
        var row = dataTable.NewRow();
        row["IsActive"] = isActive;
        row["FullName"] = Name.FullName().MaxLength(200);
        row["LastLoginDate"] = lastLoginDate;

        return row;
    }

    for (int i = 0; i < NUM_ITERATIONS; ++i)
    {
        if (i % 10 == 0) { WritePercentComplete(i, NUM_ITERATIONS); }

        dataTable.Rows.Clear();
        for (int j = 0; j < NUM_PER_ITERATION; ++j)
        {
            dataTable.Rows.Add(CreateRandomRow());
        }

        await BulkInsertAsync(TABLE_NAME, dataTable);
    }

    WriteLine("DONE");
}

async Task BulkInsertAsync(string tableName, DataTable dataTable)
{
    using SqlConnection conn = new(connectionString);
    await conn.OpenAsync();
    SqlBulkCopy bulkCopy = new(conn)
    {
        DestinationTableName = tableName
    };
    foreach (DataColumn col in dataTable.Columns)
    {
        bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName);
    }
    await bulkCopy.WriteToServerAsync(dataTable);
}

async Task ClearTableAsync(params string[] tableNames)
{
    using var conn = new SqlConnection(connectionString);
    await conn.OpenAsync();
    foreach (string tableName in tableNames)
    {
        Write($"Clearing table {tableName}...");
        using var comm = conn.CreateCommand();
        comm.CommandTimeout = (int)TimeSpan.FromMinutes(5).TotalSeconds;
        comm.CommandText = $@"
            BEGIN TRY
                TRUNCATE TABLE {tableName};
            END TRY
            BEGIN CATCH
                PRINT 'Cannot truncate';
            END CATCH;
            WHILE 1=1
            BEGIN
                DELETE TOP (5000) {tableName};
                IF @@ROWCOUNT = 0 BREAK;
            END;";
        await comm.ExecuteNonQueryAsync();
        WriteLine("DONE");
    }
}

async Task ResetIdentityAsync(params string[] tableNames)
{
    using var conn = new SqlConnection(connectionString);
    await conn.OpenAsync();
    foreach (string tableName in tableNames)
    {
        WriteLine($"Resetting identity on {tableName}");
        using var comm = conn.CreateCommand();
        comm.CommandText = "DBCC CHECKIDENT(@TableName, RESEED, 0);";
        comm.Parameters.Add(new SqlParameter("@TableName", SqlDbType.NVarChar, 128) { Value = tableName });
        await comm.ExecuteNonQueryAsync();
    }
}

void WritePercentComplete(int current, int max)
{
    string percentCompleteText = (int)(100 * (decimal)current / max) + "%";
    Write(percentCompleteText);
    SetCursorPosition(CursorLeft - percentCompleteText.Length, CursorTop);
}

public static class Extensions
{
    public static string MaxLength(this string s, int maxLength) => s.Length > maxLength ? s.Substring(0, maxLength) : s;
}
