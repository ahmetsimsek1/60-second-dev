using System;
using Stubble.Core.Builders;

static class ChangedDelimiters
{
    public static void Go()
    {
        const string MESSAGE_TEMPLATE = @"
{{=<% %>=}}
public class Program 
{
    public string <%PropertyName%> { get; set; }
}
";
        var stubble = new StubbleBuilder().Build();

        var obj = new { PropertyName = "BuildingName" };

        var result = stubble.Render(MESSAGE_TEMPLATE, obj);

        Console.WriteLine(result);
    }
}
