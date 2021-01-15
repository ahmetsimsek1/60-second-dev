using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

static class Option2
{
    private static DataTable GetMoviesDataTable(IEnumerable<Movie> movies)
    {
        var dt = new DataTable();
        dt.Columns.Add("Title");
        dt.Columns.Add("ReleaseDate");
        dt.Columns.Add("Rating");

        foreach (var movie in movies)
        {
            var row = dt.NewRow();
            dt.Rows.Add(row);
            row["Title"] = movie.Title;
            row["ReleaseDate"] = movie.ReleaseDate;
            row["Rating"] = movie.Rating;
        }
        return dt;
    }

    public static async Task GoAsync()
    {
        using var conn = new SqlConnection(Program.CONNECTION_STRING);
        await conn.OpenAsync().ConfigureAwait(false);
        using var comm = conn.CreateCommand();
        comm.CommandText = "dbo.AddMovies";
        comm.CommandType = CommandType.StoredProcedure;
        var movies = Program.GetMovies();
        var moviesParamValue = GetMoviesDataTable(movies);
        comm.Parameters.Add(new SqlParameter
        {
            ParameterName = "@Movies",
            Value = moviesParamValue,
            SqlDbType = SqlDbType.Structured,
            TypeName = "dbo.MovieType"
        });
        await comm.ExecuteNonQueryAsync().ConfigureAwait(false);
    }
}
