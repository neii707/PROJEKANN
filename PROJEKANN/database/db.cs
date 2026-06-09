using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;

namespace PROJEKANN.database
{
    public static class DBConnection
    {
        private static readonly string connectionString =
<<<<<<< HEAD
            "Host=localhost;Port=5432;Database=databasecweed;Username=postgres;Password=191206;";
=======
            "Host=localhost;Port=5432;Database=projek akhir cweed;Username=postgres;Password=neina776;";
>>>>>>> 9e4737c7661c17ff4c8ea961144f314b2eba2839

        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(connectionString);
        }
    }
}
