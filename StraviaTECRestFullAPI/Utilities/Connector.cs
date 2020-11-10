using Microsoft.AspNetCore.Identity;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace StraviaTECRestFullAPI.Utilities
{
    public static class Connector
    {
        private static NpgsqlConnection connection = new NpgsqlConnection("Host=jongs.mynetgear.com;Port=5432;Username=Stravia_REST-API;Password=&fPcp8l<0oxmZQq]J;Database=StraviaTEC_DB");

        public static bool checkUserPass(string username, string password)
        {
            connection.Open();

            using (NpgsqlCommand cmd = new NpgsqlCommand("\"CheckPassword\"", connection))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_username", username);
                cmd.Parameters.AddWithValue("_password", password);
                bool result = (bool)cmd.ExecuteScalar();

                connection.Close();

                return result;
            }
        }

        public static string generatedUserPassHash(string username, string password)
        {
            connection.Open();

            using (NpgsqlCommand cmd = new NpgsqlCommand("\"GenerateHashPassword\"", connection))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_username", username);
                cmd.Parameters.AddWithValue("_password", password);
                string result = (string)cmd.ExecuteScalar();

                connection.Close();

                return result;
            }
        }
    }
}
