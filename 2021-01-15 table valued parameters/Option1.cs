using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Data.SqlClient.Server;

static class Option1
{
    static SqlMetaData[] movieMetaData = {
        new SqlMetaData("Title", SqlDbType.NVarChar, 100),
        new SqlMetaData("ReleaseDate", SqlDbType.Date),
        new SqlMetaData("Rating", SqlDbType.TinyInt)
    };

    static SqlDataRecord CreateMovieRecord(Movie movie)
    {
        var record = new SqlDataRecord(movieMetaData);
        record.SetString(0, movie.Title);
        record.SetDateTime(1, movie.ReleaseDate);
        if (movie.Rating.HasValue)
        {
            record.SetByte(2, movie.Rating.Value);
        }
        return record;
    }

    public static async Task GoAsync()
    {
        using var conn = new SqlConnection(Program.CONNECTION_STRING);
        await conn.OpenAsync().ConfigureAwait(false);
        using var comm = conn.CreateCommand();
        comm.CommandText = "dbo.AddMovies";
        comm.CommandType = CommandType.StoredProcedure;
        var movies = Program.GetMovies();
        var moviesParamValue = movies.Select(CreateMovieRecord).ToArray();
        if (!moviesParamValue.Any())
        {
            moviesParamValue = null;
        }
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
