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
            "Host=localhost;Port=5432;Database=DATABASECWEED;Username=postgres;Password=191206;";
=======
            "Host=localhost;Port=5432;Database=projek akhir cweed;Username=postgres;Password=neina776;";
>>>>>>> f5b59369607bb5e12d4a1ae0e2ae81e9229e9f8d


        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(connectionString);
        }
    }
}
