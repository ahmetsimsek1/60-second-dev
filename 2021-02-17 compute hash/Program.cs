using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Force.Crc32;

if (args == null || !args.Any() || (args.Length != 1 && args.Length != 3))
{
    ShowInstructions();
    return;
}

if (!File.Exists(args[0]))
{
    throw new ApplicationException($"File does not exist: {args[0]}");
}

using var fs = File.OpenRead(args[0]);

if (args.Length == 1)
{
    await ShowMenuAsync().ConfigureAwait(false);
    return;
}

byte[] hash = args[1] switch
{
    "--crc32" => await CRC32Async(fs).ConfigureAwait(false),
    "--sha1" => await SHA1Async(fs).ConfigureAwait(false),
    "--sha256" => await SHA256Async(fs).ConfigureAwait(false),
    "--md5" => await MD5Async(fs).ConfigureAwait(false),
    _ => throw new ApplicationException("Invalid argument: must be { --crc32, --sha1, --sha256, --md5 }")
};

string formattedHash = args[2] switch
{
    "--hex" => GetHex(hash),
    "--HEX" => GetHex(hash, upper: true),
    "--base64" => Convert.ToBase64String(hash),
    _ => throw new ApplicationException("Invalid argument: must be { --hex, --HEX, --base64 }")
};

Console.Out.Write(formattedHash);

Environment.Exit(0);
return;

async Task<byte[]> CRC32Async(Stream stream) => await HashAsync(stream, () => new Crc32Algorithm()).ConfigureAwait(false);
async Task<byte[]> SHA1Async(Stream stream) => await HashAsync(stream, () => SHA1.Create()).ConfigureAwait(false);
async Task<byte[]> SHA256Async(Stream stream) => await HashAsync(stream, () => SHA256.Create()).ConfigureAwait(false);
async Task<byte[]> MD5Async(Stream stream) => await HashAsync(stream, () => MD5.Create()).ConfigureAwait(false);

async Task<byte[]> HashAsync(Stream stream, Func<HashAlgorithm> getAlgorithm)
{
    using var algo = getAlgorithm();
    return await algo.ComputeHashAsync(stream).ConfigureAwait(false);
}

void ShowInstructions()
{
    Console.WriteLine("Usage:");
    Console.WriteLine($"ComputeHash.exe FULL_PATH_TO_FILE");
    Console.WriteLine("With no hash parameters, you'll get an interactive menu.");
    Console.WriteLine($"ComputeHash.exe FULL_PATH_TO_FILE < --crc32 | --sha1 | --sha256 | --md5 > < --hex | --HEX | --base64 >");
    Console.WriteLine("If you pass in a hash parameter, it will be written to the output. Only one algorithm is allowed.");
    Environment.Exit(1);
}

async Task ShowMenuAsync()
{
    Console.WriteLine($"Calculate hash for {args[0]}");
    Console.WriteLine();
    Console.WriteLine("1: CRC32");
    Console.WriteLine("2: SHA1");
    Console.WriteLine("3: SHA256");
    Console.WriteLine("4: MD5");
    Console.WriteLine();
    Console.Write("Make a selection: ");
    byte[] hash = Console.ReadLine() switch
    {
        "1" => await CRC32Async(fs).ConfigureAwait(false),
        "2" => await SHA1Async(fs).ConfigureAwait(false),
        "3" => await SHA256Async(fs).ConfigureAwait(false),
        "4" => await MD5Async(fs).ConfigureAwait(false),
        _ => throw new ApplicationException("Invalid selection")
    };
    Console.WriteLine();
    Console.WriteLine($"Base64: {Convert.ToBase64String(hash)}");
    Console.WriteLine($"hex: {GetHex(hash)}");
    Console.WriteLine($"HEX: {GetHex(hash, upper: true)}");
    Console.WriteLine("Press ENTER to exit...");
    Console.ReadLine();
    Environment.Exit(0);
}

string GetHex(byte[] bytes, bool upper = false)
    => string.Join("", bytes.Select(b => b.ToString(upper ? "X2" : "x2")));
