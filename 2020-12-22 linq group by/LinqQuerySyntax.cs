using static System.Console;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class LinqQuerySyntax
{
    private MyContext _context;
    public LinqQuerySyntax(MyContext context) => _context = context;

    public async Task GoAsync()
    {
        WriteLine($"\n** Query Syntax **\n");
        var itemQuery =
            from s in _context.Stores
            group s by new { s.Country.CountryName, s.RegionName } into g
            where g.Count() > 1
            orderby g.Count() descending
            select new { g.Key.CountryName, g.Key.RegionName, NumStores = g.Count() };

        WriteLine(itemQuery.ToQueryString());
        WriteLine();

        foreach (var item in await itemQuery.ToArrayAsync().ConfigureAwait(false))
        {
            WriteLine($"{item.CountryName}-{item.RegionName}: {item.NumStores}");
        }

        WriteLine();
    }
}