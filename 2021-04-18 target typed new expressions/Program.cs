using System.Collections.Generic;

// Intro of "var" changed:
Dictionary<int, string> dictionary = new Dictionary<int, string>();
var dictionary2 = new Dictionary<int, string>();

// var sometimes is abused:
var something = GetValueFromSomewhere(); // What type is "something"?

// Each of these three are equivalent
// The object is a Foo, and the variable is type Foo

Foo foo1 = new Foo();
var foo2 = new Foo();
Foo foo3 = new();

// When you want your variable to be an interface or a base class, you can't
// use the new syntax - you still have to do it the old fashioned way.
// These are practically the same - might compile a little differently, but
// the end result is the same.
// The variable is of type IFoo, and the object is a Foo
IFoo foo4 = new Foo();
var foo5 = new Foo() as IFoo;
var foo6 = (IFoo)new Foo();

// This is not allowed because IFoo is an interface
// It would be like saying new IFoo()
IFoo foo7 = new();

// You can use the new() syntax inside a method where it's clear
// what kind of object you're talking about
// These two are equivalent
Foo.Go(new());
Foo.Go(new Foo());

// This is not allowed because it would be ambiguous between the overloads
Foo.Go2(new());

// You can still use initializers:
Foo foo8 = new() { Msg = "Hello" };

// This is different from anonymous types because you still need the parenthesis
var something = new { Msg = "World" }; // Not a Foo
Foo foo9 = new { Msg = "Something" }; // This will not work

// Collection initializers are easier now as well
Dictionary<int, Foo> list = new()
{
    { 1, new("one") },
    { 2, new("two") }
};

interface IFoo { }
class Foo : IFoo
{
    public Foo() { }
    public Foo(string msg) { Msg = msg };
    public string Msg { get; init; }
    public static void Go(Foo foo) { }
    public static void Go2(Foo foo) { }
    public static void Go2(Bar bar) { }
}

class Bar { }