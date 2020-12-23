using static System.Console;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;

static class Sql
{
    public static async Task GoAsync()
    {
        WriteLine($"\n** SQL **\n");
        using var conn = new SqlConnection(Constants.ConnectionString);
        await conn.OpenAsync().ConfigureAwait(false);
        using var comm = conn.CreateCommand();
        comm.CommandText = @"
            select c.CountryName, s.RegionName, count(1) [NumStores]
            from dbo.Stores s
            join dbo.Countries c on s.CountryID = c.CountryID
            group by c.CountryName, s.RegionName
            having count(1) > 1
            order by count(1) desc;
        ";

        WriteLine(comm.CommandText);
        WriteLine();

        using var rdr = await comm.ExecuteReaderAsync().ConfigureAwait(false);
        while (await rdr.ReadAsync().ConfigureAwait(false))
        {
            WriteLine($"{rdr["CountryName"]}-{rdr["RegionName"]}: {rdr["NumStores"]}");
        }
        WriteLine();
    }
}
