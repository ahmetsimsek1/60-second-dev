using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Linq;

const string CONNECTION_STRING = "Server=(localdb)\\MSSqlLocalDB;Database=sandbox;Integrated Security=true;";

byte[] input = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
Console.WriteLine($"\nInput: {FormatBytes(input)}");

string base64 = Convert.ToBase64String(input);
string sqlBase64 = SqlConvertToBase64String(input);

Console.WriteLine($"\n.NET: {base64}");
Console.WriteLine($" SQL: {sqlBase64}");

byte[] output = SqlConvertFromBase64String(sqlBase64);

Console.WriteLine($"\nOutput: {FormatBytes(output)}");

static string SqlConvertToBase64String(byte[] input)
{
    using var conn = new SqlConnection(CONNECTION_STRING);
    conn.Open();
    using var comm = conn.CreateCommand();
    comm.CommandText = "select util.ConvertToBase64(@Input);";
    comm.Parameters.Add(new SqlParameter("@Input", SqlDbType.VarBinary, -1) {
        Value = input
    });
    return (string)comm.ExecuteScalar();
}

static byte[] SqlConvertFromBase64String(string input)
{
    using var conn = new SqlConnection(CONNECTION_STRING);
    conn.Open();
    using var comm = conn.CreateCommand();
    comm.CommandText = "select util.ConvertFromBase64(@Input);";
    comm.Parameters.Add(new SqlParameter("@Input", SqlDbType.NVarChar, -1) {
        Value = input
    });
    return (byte[])comm.ExecuteScalar();
}

static string FormatBytes(byte[] input) => string.Join(", ", input);
