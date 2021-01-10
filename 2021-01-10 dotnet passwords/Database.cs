// Demo only, obviously
public static class Database
{
    public static byte[] Hash { get; set; }
    public static byte[] Salt { get; set; }

    public static void Write(string userName, byte[] hash, byte[] salt)
        => (Hash, Salt) = (hash, salt);

    public static (byte[] Hash, byte[] Salt) GetFromDatabase(string userName)
        => (Hash, Salt);
}
