using System;
using System.Text.Json;

CustomClass.Go();
OldTuples.Go();
OutParameters.Go();
OldWayNewCall.Go();
PropertyNames.Go();
NoPropertyNames.Go();
var c = new Constructor(1, "Hello", DateTime.Now);
Console.WriteLine(JsonSerializer.Serialize(c));
