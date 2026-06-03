using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;

namespace PROJEKANN.database
{
    public static class DBConnection
    {
        private static readonly string connectionString =
            "Host=localhost;Port=5432;Database=projek akhir cweed;Username=postgres;Password=neina776;";

        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(connectionString);
        }
    }
}
