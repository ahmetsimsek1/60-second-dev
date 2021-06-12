using System;
using System.IO;
using System.Linq;
using static System.Console;

// Traditional AND logic:
// &: non-short-circuiting AND (also bitwise AND)
// &&: short-circuiting AND

WriteLine("AND:");
WriteLine(GetTrue() & GetFalse()); // GetTrue | GetFalse | False
WriteLine(GetTrue() && GetFalse()); // GetTrue | GetFalse | False
WriteLine(GetFalse() & GetTrue()); // GetFalse | GetTrue | False
WriteLine(GetFalse() && GetTrue()); // GetFalse | False (short-circuited)

// Traditional OR logic:
// |: non-short-circuiting OR (also bitwise OR)
// ||: short-circuiting OR

WriteLine("OR:");
WriteLine(GetTrue() | GetFalse()); // GetTrue | GetFalse | True
WriteLine(GetTrue() || GetFalse()); // GetTrue | True (short-circuited)
WriteLine(GetFalse() | GetTrue()); // GetFalse | GetTrue | True
WriteLine(GetFalse() || GetTrue()); // GetFalse | GetTrue | True

// Pattern matching with "is", "and", "or", "not":

int i = 5;

// Between (old way)
if (i >= 2 && i <= 7) { WriteLine("between 2 and 7"); }

// Between (new way)
if (i is >= 2 and <= 7) { WriteLine("between 2 and 7"); }

// Is one of (old ways)
if (new[] { 1, 2, 3 }.Contains(i)) { WriteLine("In 1, 2, 3"); }
if (Array.IndexOf(new[] { 1, 2, 3 }, i) >= 0) { WriteLine("In 1, 2, 3"); }
if (i == 1 || i == 2 || i == 3) { WriteLine("In 1, 2, 3"); }

// Is one of (new way)
if (i is 1 or 2 or 3) { WriteLine("In 1, 2, 3"); }

// Check if something matches a type or not
TextReader rdr = new StreamReader(new MemoryStream());
if (rdr is StringReader strr) { WriteLine("Is a StringReader"); }
if (rdr is not StreamReader) { WriteLine("Is not a StreamReader"); }

// Switch
string message = i switch
{
    < 0 or > 5000 => "Less than zero or greater than 5000",
    < 2 => "Less than two",
    > 10 and < 50 => "Between 10 and 50 exclusive",
    not < 100 => "Not less than 100",
    _ => "Something else"
};
WriteLine(message);


bool GetTrue() { WriteLine("GetTrue"); return true; }
bool GetFalse() { WriteLine("GetFalse"); return false; }
