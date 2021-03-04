using System;
using System.Globalization;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine();

decimal dec = 12345.678m;
int integer = 491;

// These are all equivalent
Console.WriteLine(dec.ToString("C"));
Console.WriteLine($"{dec:C}");
Console.WriteLine("{0:C}", dec);

WriteDecimal(""); // Default: 12345.678 for US | 12345,678 for France
WriteDecimal("C"); // Currency: $12,345.68 for US | 12 345,68 € for France

WriteInt("D"); // Decimal (actually integer): 491
WriteInt("D4"); // Decimal (actually integer) to 4 places: 0491

WriteDecimal("F5"); // Fixed point: 12345.67800 for US | 12345,67800 for France
WriteDecimal("F1"); // Fixed point: 12345.7 for US | 12345,7 for France

WriteDecimal("N"); // Numeric: 12,345.678 for US | 12 345,678 for France

WriteInt("X"); // Hex in upper-case: 1EB
WriteInt("x8"); // Hex in lower-case, to 8 digits: 000001eb

WriteDecimal("#,##0.00"); // Digit separator, 2 required decimals: 12,345.68 for US | 12 345,68 for France

WriteDecimal(@"#\,###"); // Specifically using a comma as the digit separator: 12,346

void WriteDecimal(string format)
{
    Console.WriteLine($"Format: {format}");
    Console.WriteLine($"US: {dec.ToString(format, new CultureInfo("en-US"))}");
    Console.WriteLine($"France: {dec.ToString(format, new CultureInfo("fr-FR"))}");
    Console.WriteLine();
}

void WriteInt(string format)
{
    Console.WriteLine($"Format: {format}");
    Console.WriteLine($"US: {integer.ToString(format, new CultureInfo("en-US"))}");
    Console.WriteLine($"France: {integer.ToString(format, new CultureInfo("fr-FR"))}");
    Console.WriteLine();
}
