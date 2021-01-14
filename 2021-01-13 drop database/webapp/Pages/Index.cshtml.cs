using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace webapp.Pages
{
    public class IndexModel : PageModel
    {
        public List<string> SongNames { get; set; } = new List<string>();

        private readonly string _connectionString;
        public IndexModel(IConfiguration config)
            => _connectionString = config.GetConnectionString("PolkaJukebox");

        public async Task OnGet()
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync().ConfigureAwait(false);
            using var comm = conn.CreateCommand();
            comm.CommandText = @"select SongTitle from dbo.Songs;";
            using var rdr = await comm.ExecuteReaderAsync().ConfigureAwait(false);
            while (await rdr.ReadAsync().ConfigureAwait(false))
            {
                SongNames.Add(rdr.GetString(rdr.GetOrdinal("SongTitle")));
            }
        }
    }
}
