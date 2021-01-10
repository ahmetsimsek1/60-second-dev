using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

public static class Passwords
{

    /// <summary>
    /// 256-bit (32 byte) password.
    /// Use this when you already have the salt value and are checking the value.
    /// </summary>
    /// <param name="password"></param>
    /// <param name="salt"></param>
    /// <returns></returns>
    public static byte[] HashPassword(string password, byte[] salt)
      => KeyDerivation.Pbkdf2(
        password: password,
        salt: salt,
        prf: KeyDerivationPrf.HMACSHA512,
        iterationCount: 10000,
        numBytesRequested: 32
    );

    /// <summary>
    /// 128-bit (16 byte) salt, and 256-bit (32 byte) password.
    /// Use this when generating a new hash and salt.
    /// </summary>
    /// <param name="password"></param>
    /// <returns></returns>
    public static (byte[] hash, byte[] salt) HashPassword(string password)
    {
        using var rng = RandomNumberGenerator.Create();
        var salt = new byte[16];
        rng.GetBytes(salt);
        var hash = HashPassword(password, salt);
        return (hash, salt);
    }
}