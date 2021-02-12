using static System.Console;
using System.Text.Json;
using System;
using System.Linq;
using System.IO;
using System.Text;

const string LOREM_IPSUM = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In fringilla, risus nec dignissim semper, dolor nisi aliquam metus, ut mollis sem mi ut ligula. Quisque tempor, odio a lacinia laoreet, nisl risus accumsan arcu, et hendrerit turpis augue nec urna. Phasellus dictum pretium pharetra. Morbi a consequat dui. Vivamus vel pulvinar mi, at ullamcorper dolor. Praesent neque mauris, finibus vitae tincidunt in, ultricies ac metus. Nulla consectetur arcu quis ante elementum dignissim.Nam id nulla quis lectus semper porttitor eu eu mi. Aenean fringilla urna et arcu ultricies maximus et at nisl. Etiam sapien dolor, suscipit in tortor sed, malesuada vulputate arcu. Cras interdum purus dui, at egestas urna mollis eu. Sed porttitor feugiat odio, sit amet lacinia est elementum in. Nulla est lacus, consectetur eu risus a, tincidunt vehicula tellus. Sed sodales in libero et malesuada. Pellentesque blandit urna sit amet dui consequat, eget tristique justo iaculis.Donec maximus congue nibh eget semper. Vestibulum in lacus laoreet, tempor tellus id, vestibulum arcu. Praesent rhoncus luctus neque, eu dignissim orci ullamcorper ac. Etiam non augue egestas, imperdiet justo eu, gravida libero. Fusce in libero eu turpis pulvinar faucibus. Donec viverra fermentum viverra. Nam purus ante, consequat non magna nec, ultricies lacinia felis. Maecenas bibendum, nisl eget consequat porta, urna nunc tristique arcu, tempor auctor dolor nisl a est. Sed volutpat, massa quis gravida molestie, mauris leo fermentum risus, vel aliquam mi nibh quis est. Phasellus nec ante nec nisi vestibulum pharetra. Donec nulla sapien, pellentesque lacinia consectetur vel, suscipit laoreet nulla. Phasellus vitae porttitor felis, nec maximus risus. Nunc in urna orci. Praesent nunc nibh, euismod et dapibus ut, cursus ac ligula. Sed tincidunt eros libero, nec ultrices eros venenatis ut.Suspendisse potenti. Ut urna dui, finibus et risus non, fermentum malesuada felis. Morbi eu gravida tellus. Nulla non leo sit amet urna facilisis lacinia. Morbi rhoncus convallis lectus vel imperdiet. Phasellus condimentum pulvinar diam nec ornare. Donec massa orci, hendrerit a pretium vitae, elementum vel erat. Proin elit mi, finibus nec gravida sit amet, elementum vel nunc. Nam a neque et dui efficitur accumsan. Nullam malesuada tincidunt tempor. Praesent et turpis at nunc lobortis tincidunt quis non neque. Sed finibus ipsum urna, quis cursus sem bibendum vitae.Sed tincidunt laoreet risus, tincidunt eleifend nulla condimentum vel. Curabitur pellentesque arcu nec dolor sodales, at lacinia lectus pulvinar. Suspendisse imperdiet et ante id aliquet. Quisque viverra nisl eget dignissim posuere. Donec nec tellus eu quam scelerisque tincidunt eu eu odio. Ut tincidunt nisi eu arcu rhoncus maximus. Ut vulputate est sed felis ullamcorper, nec blandit justo commodo. Praesent nisl massa, gravida vel interdum sit amet, molestie in massa. Ut elementum non mauris sed mollis. Mauris dictum, tortor eget efficitur venenatis, ex nibh elementum dolor, nec dictum libero justo non lacus. Praesent aliquet dolor ut sodales accumsan. Curabitur varius ultricies metus dictum commodo. Etiam nec velit quis massa varius tristique at ac ligula. Integer magna urna, malesuada eget urna at, finibus sollicitudin turpis.";

byte[] input = Encoding.UTF8.GetBytes(LOREM_IPSUM);
byte[] compressed = Brotli.Compress(input);
byte[] decompressed = Brotli.Decompress(compressed);

WriteLine($"Original: {input.Length} bytes");
WriteLine($"Compressed: {compressed.Length} bytes");
WriteLine($"Decompressed: {decompressed.Length} bytes");
WriteLine($"original {(input.SequenceEqual(decompressed) ? "matches" : "does not match")} decompressed");

WriteLine();
WriteLine();

string inputString = "Hello universe!";
compressed = Brotli.CompressString(inputString);
string decompressedString = Brotli.DecompressToString(compressed);

WriteLine("Original:");
WriteLine(inputString);
WriteLine("Compressed:");
WriteLine(JsonSerializer.Serialize(compressed));
WriteLine("Decompressed:");
WriteLine(decompressedString);

WriteLine();
WriteLine();

string inputFile = @"c:\temp\hello.txt";
string brotliFile = @"c:\temp\hello.txt.br";
if (File.Exists(inputFile)) { File.Delete(inputFile); }
if (File.Exists(brotliFile)) { File.Delete(brotliFile); }
File.WriteAllText(inputFile, "good morning captain");
Brotli.CompressFile(inputFile);

WriteLine("Original:");
WriteLine(File.ReadAllText(inputFile));
WriteLine("Compressed:");
WriteLine(JsonSerializer.Serialize(File.ReadAllBytes(brotliFile)));
File.Delete(inputFile);
Brotli.DecompressFile(brotliFile);
WriteLine("Decompressed:");
WriteLine(File.ReadAllText(inputFile));
