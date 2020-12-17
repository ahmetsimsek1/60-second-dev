using static System.Console;
using System.Text.Json;
using System;
using System.Linq;
using System.IO;

var random = new Random();
byte[] input = Enumerable.Range(0, 20).Select(i => (byte)random.Next(0, 255)).ToArray();
byte[] compressed = GZip.Compress(input);
byte[] decompressed = GZip.Decompress(compressed);

WriteLine("Original:");
WriteLine(JsonSerializer.Serialize(input));
WriteLine("Compressed:");
WriteLine(JsonSerializer.Serialize(compressed));
WriteLine("Decompressed:");
WriteLine(JsonSerializer.Serialize(decompressed));

WriteLine();
WriteLine();

string inputString = "Hello universe!";
compressed = GZip.CompressString(inputString);
string decompressedString = GZip.DecompressToString(compressed);

WriteLine("Original:");
WriteLine(inputString);
WriteLine("Compressed:");
WriteLine(JsonSerializer.Serialize(compressed));
WriteLine("Decompressed:");
WriteLine(decompressedString);

WriteLine();
WriteLine();

string inputFile = @"c:\temp\hello.txt";
string gzipFile = @"c:\temp\hello.txt.gz";
if (File.Exists(inputFile)) { File.Delete(inputFile); }
if (File.Exists(gzipFile)) { File.Delete(gzipFile); }
File.WriteAllText(inputFile, "good morning captain");
GZip.CompressFile(inputFile);

WriteLine("Original:");
WriteLine(File.ReadAllText(inputFile));
WriteLine("Compressed:");
WriteLine(JsonSerializer.Serialize(File.ReadAllBytes(gzipFile)));
File.Delete(inputFile);
GZip.DecompressFile(gzipFile);
WriteLine("Decompressed:");
WriteLine(File.ReadAllText(inputFile));
