using System;
using System.Text.Json;
using CsvHelper.Configuration.Attributes;

public class MyRecord
{
    [Name("my message")]
    public string MyMessage { get; set; }

    [Name("some text here")]
    public string SomeTextHere { get; set; }

    [Name("more text")]
    public string MoreText { get; set; }

    public decimal SomeNumber { get; set; }

    [Name("a date")]
    public DateTime ADate { get; set; }

    [Ignore]
    public string IgnoreThis { get; set; }

    public override string ToString() => @$"my message: {MyMessage}
some text here: {SomeTextHere}
more text: {MoreText}
a number: {SomeNumber}
a date: {ADate}
---------------------";
}
