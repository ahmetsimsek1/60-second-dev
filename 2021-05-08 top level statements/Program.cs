using System;
using System.Reflection;
using MyApplication;

// OLD WAY
// namespace MyApplication
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             Console.WriteLine($"Good morning {args[0]}");
//         }
//     }
// }

// NEW WAY

Console.WriteLine($"Good morning {args[0]}");

Go();

void Go()
{
    Console.WriteLine("Vroom");
}

Go();

await new Foo().GoAsync();

if (args[0] != "from reflection")
{
    var programType = Type.GetType("<Program>$");
    var methodInfo = programType.GetMethod("<Main>$", BindingFlags.Static | BindingFlags.NonPublic);
    methodInfo.Invoke(programType, new[] { new[] { "from reflection" } });
}

// New types must be at the bottom of the file. These will be in the global namespace, unless you
// wrap it in a namespace.
enum Product { Camera, Suitcase, Shoehorn }

namespace MyApplication
{
    public class Bar { }
}