using System;
using System.Threading.Tasks;

class Program
{
    public const string CONNECTION_STRING = "Server=(localdb)\\MSSqlLocalDB;Database=sandbox;Integrated Security=true;";

    public static Movie[] GetMovies() => new[] {
        new Movie("Office Space", new DateTime(1999, 2, 19), 5),
        new Movie("Spaceballs", new DateTime(1987, 6, 24), 5),
        new Movie("Gone With the WInd", new DateTime(1939, 12,15), null),
        new Movie("The Room", new DateTime(2004, 3, 3), 1)
    };

    static async Task Main()
    {
        //await Option1.GoAsync().ConfigureAwait(false);
        await Option2.GoAsync().ConfigureAwait(false);
    }
}
