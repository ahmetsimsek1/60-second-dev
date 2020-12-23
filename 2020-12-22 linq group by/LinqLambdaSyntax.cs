using static System.Console;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class LinqLambdaSyntax
{
    private MyContext _context;
    public LinqLambdaSyntax(MyContext context) => _context = context;

    public async Task GoAsync()
    {
        WriteLine($"\n** Lambda Syntax **\n");
        var itemQuery = 
            _context.Stores
                .GroupBy(s => new { s.Country.CountryName, s.RegionName })
                .Where(g => g.Count() > 1)
                .OrderByDescending(g => g.Count())
                .Select(g => new { g.Key.CountryName, g.Key.RegionName, NumStores = g.Count() });

        WriteLine(itemQuery.ToQueryString());
        WriteLine();

        foreach (var item in await itemQuery.ToArrayAsync().ConfigureAwait(false))
        {
            WriteLine($"{item.CountryName}-{item.RegionName}: {item.NumStores}");
        }

        WriteLine();
    }
}