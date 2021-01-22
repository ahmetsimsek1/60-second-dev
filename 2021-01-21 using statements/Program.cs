using System;
using System.IO;

if (args[0] == "Go1") Go1();
if (args[0] == "Go2") Go2();
if (args[0] == "Go3") Go3();

static void Go1()
{
    using (var reader = new StreamReader("input.txt"))
    {
        using (var writer = new StreamWriter("output.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                writer.WriteLine(line);
            }
        }// <----- writer gets disposed here
    } // <----- reader gets disposed here

    // File has been saved and closed, so this is ok
    Console.WriteLine(File.ReadAllText("output.txt"));
}

static void Go2()
{
    using var reader = new StreamReader("input.txt");
    using var writer = new StreamWriter("output.txt");
    string line;
    while ((line = reader.ReadLine()) != null)
    {
        writer.WriteLine(line);
    }

    // This fails because writer is still open
    Console.WriteLine(File.ReadAllText("output.txt"));
} // <----- reader and writer get disposed here

static void Go3()
{
    using (var reader = new StreamReader("input.txt")) // old style
    {
        using var writer = new StreamWriter("output.txt"); // new style
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            writer.WriteLine(line);
        }
    } // <----- reader and writer get disposed here

    // File has been saved and closed, so this is ok
    Console.WriteLine(File.ReadAllText("output.txt"));
}
