using Microsoft.Extensions.DependencyInjection;

#region SQL
await Sql.GoAsync().ConfigureAwait(false);
#endregion

#region Linq Query Syntax
var serviceProvider1 = new ServiceCollection()
    .AddTransient<MyContext>()
    .AddTransient<LinqQuerySyntax>()
    .BuildServiceProvider();

await serviceProvider1.GetService<LinqQuerySyntax>()!.GoAsync().ConfigureAwait(false);
#endregion

#region Linq Lambda Syntax
var serviceProvider2 = new ServiceCollection()
    .AddTransient<MyContext>()
    .AddTransient<LinqLambdaSyntax>()
    .BuildServiceProvider();

await serviceProvider2.GetService<LinqLambdaSyntax>()!.GoAsync().ConfigureAwait(false);
#endregion
