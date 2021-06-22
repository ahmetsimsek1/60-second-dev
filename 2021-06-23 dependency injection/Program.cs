using System;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
    .AddTransient<Manager>()
    .AddTransient<MyTransient>()
    .AddScoped<MyScoped>()
    .AddSingleton<MySingleton>()
    .BuildServiceProvider();

// All three get instantiated
Console.WriteLine("First time instantiating Manager");
var manager = serviceProvider.GetRequiredService<Manager>();
Console.WriteLine();

// Transient gets instantiated again, but the other two do not
Console.WriteLine("Second time instantiating Manager");
manager = serviceProvider.GetRequiredService<Manager>();
Console.WriteLine();

var scopeFactory = serviceProvider.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    // Transient and Scoped get instantiated again, but Singleton does not
    Console.WriteLine("Instantiating Manager inside a new scope");
    manager = scope.ServiceProvider.GetRequiredService<Manager>();

    // Transient and Scoped get disposed here
}
Console.WriteLine();

using (var scope = scopeFactory.CreateScope())
{
    // Transient and Scoped get instantiated again, but Singleton does not
    Console.WriteLine("Instantiating Manager inside a new scope");
    manager = scope.ServiceProvider.GetRequiredService<Manager>();

    // Transient and Scoped get disposed here
}
Console.WriteLine();

// All remaining disposables will be disposed here
Console.WriteLine("Disposing of the service provider");
serviceProvider.Dispose();
Console.WriteLine("DONE");

class Manager
{
    private readonly MyTransient _transient;
    private readonly MyScoped _scoped;
    private readonly MySingleton _singleton;
    public Manager(MyTransient transient, MyScoped scoped, MySingleton singleton)
        => (_transient, _scoped, _singleton) = (transient, scoped, singleton);
}

class MyTransient : IDisposable
{
    private readonly int _id = IdGenerator.GetNext();
    public MyTransient() => Console.WriteLine($"MyTransient constructor: {_id}");
    public void Dispose() => Console.WriteLine($"Disposing MyTransient {_id}");
}

class MyScoped : IDisposable
{
    private readonly int _id = IdGenerator.GetNext();
    public MyScoped() => Console.WriteLine($"MyScoped constructor: {_id}");
    public void Dispose() => Console.WriteLine($"Disposing MyScoped {_id}");
}

class MySingleton : IDisposable
{
    private readonly int _id = IdGenerator.GetNext();
    public MySingleton() => Console.WriteLine($"MySingleton constructor: {_id}");
    public void Dispose() => Console.WriteLine($"Disposing MySingleton {_id}");
}

class IdGenerator
{
    private static int _current;
    public static int GetNext()
    {
        Interlocked.Increment(ref _current);
        return _current;
    }
}