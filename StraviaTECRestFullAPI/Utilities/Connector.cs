using Microsoft.AspNetCore.Identity;
using Npgsql;
using StraviaTECRestFullAPI.Models;
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

        public static bool savePhoto(string token, string path) {

            connection.Open();

            using (NpgsqlCommand cmd = new NpgsqlCommand("\"UploadPhotoPath\"", connection))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_token", token);
                cmd.Parameters.AddWithValue("_path", path);
                bool result = (bool)cmd.ExecuteScalar();

                connection.Close();

                return result;
            }

        }

        public static string getPhotoPath(string token)
        {
            connection.Open();

            using (NpgsqlCommand cmd = new NpgsqlCommand("\"GetPhotoPath\"", connection))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_token", token);
                string result = (string)cmd.ExecuteScalar();

                connection.Close();

                return result;
            }
        }

        public static List<Athlete> searchAthleteBasedOnTerm(string term)
        {
            connection.Open();

            using (NpgsqlCommand cmd = new NpgsqlCommand("\"GetRangeOfAthletes\"", connection))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_startindex", 0);
                cmd.Parameters.AddWithValue("_finishindex", 0);
                cmd.Parameters.AddWithValue("_searchterm", term);
                var result = cmd.ExecuteReader();

                List<Athlete> currentAthletes = new List<Athlete>();

                while (result.Read())
                {
                    int index = 0;
                    List<String> attributes = new List<string>();
                    while (true)
                    {
                        try
                        {
                            attributes.Add(result.GetValue(index).ToString());
                            index++;
                        }
                        catch (Exception)
                        {
                            break;
                        }
                    }

                    currentAthletes.Add(new Athlete(attributes[0], attributes[1], attributes[2], attributes[3], attributes[4], attributes[5], attributes[6], attributes[7],
                       attributes[8], attributes[9], attributes[10], int.Parse(attributes[11]), int.Parse(attributes[12]), int.Parse(attributes[13]), int.Parse(attributes[14])));
                }

                connection.Close();

                return currentAthletes;
            }
        }
    }
}
