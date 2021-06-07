using System;

// First scenario - an object can equal null
Foo foo = new Foo { ID = null };
Console.WriteLine(foo == null); // True
Console.WriteLine(foo != null); // False
Console.WriteLine(foo is null); // False
Console.WriteLine(foo is not null); // True

// Second scenario - null doesn't have to equal null
Bar bar = new Bar { ID = null };
Bar nullBar = null;
Console.WriteLine(bar == null); // False
Console.WriteLine(bar != null); // True
Console.WriteLine(bar is null); // False
Console.WriteLine(bar is not null); // True
Console.WriteLine(nullBar == null); // False
Console.WriteLine(nullBar == nullBar); // False
Console.WriteLine(nullBar is null); // True;


// Equal if the ID property matches - a null reference is
// equal to an object with a null ID
class Foo
{
    public int? ID { get; set; }
    public static bool operator ==(Foo foo1, Foo foo2) => foo1?.ID == foo2?.ID;
    public static bool operator !=(Foo foo1, Foo foo2) => !(foo1 == foo2);
    public override bool Equals(object obj) => this == obj as Foo;
    public override int GetHashCode() => ID.GetHashCode();
}

// Not equal if one or both of the items are null -
// null is not equal to null
class Bar
{
    public int? ID { get; set; }
    public static bool operator ==(Bar bar1, Bar bar2)
    {
        if (bar1 is null || bar2 is null) { return false; }
        return bar1.ID == bar2.ID;
    }
    public static bool operator !=(Bar bar1, Bar bar2) => !(bar1 == bar2);
    public override bool Equals(object obj) => this == obj as Bar;
    public override int GetHashCode() => ID.GetHashCode();
}
