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
<<<<<<< HEAD
            "Host=localhost;Port=5432;Database=projekdb;Username=postgres;Password=060930;";
=======
<<<<<<< HEAD
            "Host=localhost;Port=5432;Database=DATABASECWEED;Username=postgres;Password=191206;";
=======
            "Host=localhost;Port=5432;Database=projek akhir cweed;Username=postgres;Password=neina776;";
>>>>>>> f5b59369607bb5e12d4a1ae0e2ae81e9229e9f8d
>>>>>>> ca04131e180f8946d385a0a08225f11ef7a6a3a3
=======
            "Host=localhost;Port=5432;Database=DATABASECWEED;Username=postgres;Password=191206;";
>>>>>>> 9eae111dfd2969aba32a7d4f986bba1c7779c686


        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(connectionString);
        }
    }
}
