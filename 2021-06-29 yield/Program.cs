using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.IO;
using Microsoft.Data.SqlClient;
using System.Data;

foreach (int i in GetSomeNumbers())
{
    WriteLine(i);
}


IEnumerable<int> GetSomeNumbers()
{
    yield return 2;
    yield return 5;
    yield return 7;
}

int[] numbers = GetSomeNumbers().ToArray(); // [ 2, 5, 7 ]

///////////////////////////////////////////////////////

foreach (long l in TimesTwo(2))
{
    WriteLine(l);
    if (l > 120000)
    {
        break;
    }
}

static IEnumerable<long> TimesTwo(long starting)
{
    long val = starting;
    while (true)
    {
        val *= 2;

        // If you don't break out of the loop, either here or by the caller,
        // you'll end up with an exception
        // if (val > 120000)
        // {
        //     yield break;
        // }

        yield return val;
    }
}

// IndexOutOfRangeException or possibly OutOfMemoryException
// long[] longs = TimesTwo(2).ToArray(); 

///////////////////////////////////////////////////////

foreach ((string url, string contents) in GetSearchEngines())
{
    WriteLine($"{url}\n{contents}\n---------------\n");
}

IEnumerable<(string url, string contents)> GetSearchEngines()
{
    string[] urls = { "https://google.com", "https://duckduckgo.com/", "https://bing.com" };
    foreach (string url in urls)
    {
        using var wc = new WebClient();
        wc.BaseAddress = url;
        string contents = wc.DownloadString("");
        yield return (url, contents);
    }
}

///////////////////////////////////////////////////////

using var imageFile = File.OpenWrite(@"/tmp/image.png");
foreach (byte[] chunk in DownloadImageFromDatabase(34))
{
    imageFile.Write(chunk, 0, chunk.Length);
}

IEnumerable<byte[]> DownloadImageFromDatabase(int fileID)
{
    int startingByte = 1;
    using SqlConnection conn = new("Server=xxxxx;Database=yyyyy;Integrated Security=True;");
    conn.Open();
    while (true)
    {
        byte[] bytes;
        using var comm = conn.CreateCommand();
        comm.CommandText = @"
            SELECT SUBSTRING(FileContents, @StartingByte, 8000) [FileContents]
            FROM dbo.Files
            WHERE FileID = @FileID;
        ";
        comm.Parameters.Add(new SqlParameter("@FileID", SqlDbType.Int) { Value = fileID });
        comm.Parameters.Add(new SqlParameter("@StartingByte", SqlDbType.Int) { Value = startingByte });
        using var rdr = comm.ExecuteReader();
        if (!rdr.Read())
        {
            break;
        }
        bytes = (byte[])rdr[0];
        if (bytes == null || bytes.Length == 0)
        {
            break;
        }
        startingByte += bytes.Length;
        yield return bytes;
    }
}
