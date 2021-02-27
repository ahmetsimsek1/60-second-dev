using System;
using System.Collections.Generic;
using Stubble.Core.Builders;

static class Standard
{
    public static void Go()
    {
        const string MESSAGE_TEMPLATE = @"
<main>
    <p>Good morning {{CustomerName}}, thank you for reading your email.</p>
    <p>Here are your transactions:</p>
    <ul>
        {{#Transactions}}
            {{> Transaction}}
        {{/Transactions}}
    </ul>
</main>
{{#Greeting}}
<footer>Goodbye!</footer>
{{/Greeting}}
{{^Greeting}}
<!-- No greeting -->
{{/Greeting}}
";

        const string TRANSACTION_TEMPLATE = "<li>{{Date_Formatted}}: {{Description}}</li>\n";

        var stubble = new StubbleBuilder().Build();

        var obj = new CustomerMessage("Mickey Mouse", new[]
            {
                new Transaction(new DateTime(2021, 3, 1), "Item #1"),
                new Transaction(new DateTime(2021, 3, 2), "Item #2")
            }, true);

        var partials = new Dictionary<string, string>
            {
                { "Transaction", TRANSACTION_TEMPLATE }
            };

        var result = stubble.Render(MESSAGE_TEMPLATE, obj, partials);

        Console.WriteLine(result);
    }
}