using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Main");
        new Foo().Go();
        Foo.StaticGo();
        Foo.StaticGo();

        new Bar<int>().Go();
        new Bar<string>().Go();
        
    }
}

class Foo
{
    static Foo() => Console.WriteLine("Foo static constructor");
    public Foo() => Console.WriteLine("Foo constructor");
    public void Go() => Console.WriteLine("Foo Go");
    public static void StaticGo() => Console.WriteLine("Foo StaticGo");
}

class Bar<T>
{
    static Bar() => Console.WriteLine($"Bar static constructor for type {typeof(T).Name}");
    public Bar() => Console.WriteLine($"Bar constructor for type {typeof(T).Name}");
    public void Go() => Console.WriteLine($"Bar Go for type {typeof(T).Name}");
    public static void StaticGo() => Console.WriteLine($"Bar StaticGo for type {typeof(T).Name}");
}
