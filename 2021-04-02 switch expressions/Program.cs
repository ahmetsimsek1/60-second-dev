using System;

// Old old way
string value = "hello";
switch (value) // Must be a simple type like string, number, or enum
{
    // cases must be constant values
    case "hi": Console.WriteLine("You said hi!"); break;
    case "hello": Console.WriteLine("Hello to you as well"); break;
}

// switching on type
Foo item = new Bar();
switch (item)
{
    // you can make variables, or use a discard
    case Baz baz: Console.WriteLine($"{baz.ID}: What's a baz, anyway?"); break;
    case Bar bar: Console.WriteLine($"{bar.ID}: That's a high bar"); break;
    case Foo _: Console.WriteLine("I pity the foo!"); break;
}

// switch expression
int id = 34;
string name = id switch
{
    10 => "ten",
    34 => "thirty four",
    45 => "forty five",
    _ => "something else"
};

// switching based on a property value
var someFoo = new Foo { ID = 10 };
name = someFoo switch
{
    { ID: 5 } => "five",
    { ID: 10 } => "ten",
    { ID: 15 } => "fifteen",
    _ => "something else"
};

// switch expression based on type
name = item switch
{
    Baz baz => "it's a baz",
    Bar bar => "it's a bar",
    Foo foo => "it's a foo",
    _ => "it's something else"
};

// combining type and property
name = item switch
{
    Baz { ID: 10 } => "ten baz",
    Baz { ID: 20 } => "twenty baz",
    Foo foo => "it's a foo!"
};

// when: a more powerful version of the property check
name = item switch 
{
    Baz baz when baz.ID > 100 => "baz with a high ID",
    _ => "something else"
};

class Foo { public int ID { get; set; } }
class Bar : Foo { }
class Baz : Bar { }
