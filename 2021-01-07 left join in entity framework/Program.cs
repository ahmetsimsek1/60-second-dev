using System;
using System.Linq;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

using var context = new MyContext();
var firstQuery = (from p in context.People
                  select new
                  {
                      p.PersonID,
                      p.FirstName,
                      FoodID = (int?)p.FavoriteFood!.FoodID,
                      FoodName = (string?)p.FavoriteFood!.FoodName
                  });


var secondQuery = (from p in context.People
                   from f in context.Foods
                        .Where(f => f.FoodID == p.FavoriteFoodID)
                        .DefaultIfEmpty()
                   select new
                   {
                       p.PersonID,
                       p.FirstName,
                      FoodID = (int?)f.FoodID,
                      FoodName = (string?)f.FoodName
                   });

Console.WriteLine();
Console.WriteLine(firstQuery.ToQueryString());
Console.WriteLine();
Console.WriteLine(secondQuery.ToQueryString());
Console.WriteLine();

Console.WriteLine(JsonSerializer.Serialize(firstQuery.ToArray(), new JsonSerializerOptions
{
    WriteIndented = true
}));
Console.WriteLine();
Console.WriteLine(JsonSerializer.Serialize(secondQuery.ToArray(), new JsonSerializerOptions
{
    WriteIndented = true
}));
Console.WriteLine();