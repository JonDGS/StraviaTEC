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

        public static List<FoundAthlete> searchAthleteBasedOnTerm(string term)
        {
            connection.Open();

            using (NpgsqlCommand cmd = new NpgsqlCommand("\"GetRangeOfAthletes\"", connection))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_startindex", 0);
                cmd.Parameters.AddWithValue("_finishindex", 0);
                cmd.Parameters.AddWithValue("_searchterm", term);
                var result = cmd.ExecuteReader();

                List<FoundAthlete> currentAthletes = new List<FoundAthlete>();

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

                    currentAthletes.Add(new FoundAthlete(attributes[0], attributes[7], attributes[8], int.Parse(attributes[11])));
                }

                connection.Close();

                foreach(FoundAthlete foundAthlete in currentAthletes)
                {
                    foundAthlete.calculateAmountOfActivities();
                }

                return currentAthletes;
            }
        }

        public static int getNumberOfActivitiesByAthlete(string username)
        {
            connection.Open();

            using (NpgsqlCommand cmd = new NpgsqlCommand("\"CountActivitiesByUser\"", connection))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_username", username);
                int result = int.Parse((string)cmd.ExecuteScalar());

                connection.Close();

                return result;
            }
        }

        public static bool validateToken(string token)
        {
            connection.Open();

            using (NpgsqlCommand cmd = new NpgsqlCommand("\"ValidateToken\"", connection))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_token", token);
                bool result = (bool)cmd.ExecuteScalar();

                connection.Close();

                return result;
            }
        }

        public static bool createChallenge(string token, string name, string startDate, string finishDate, string activity_type)
        {
            connection.Open();

            using (NpgsqlCommand cmd = new NpgsqlCommand("\"CreateChallenge\"", connection))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_name", name);
                cmd.Parameters.AddWithValue("_startDate", startDate);
                cmd.Parameters.AddWithValue("_finishDate", finishDate);
                cmd.Parameters.AddWithValue("_activity_type", activity_type);
                cmd.Parameters.AddWithValue("_token", token);
                bool result = (bool)cmd.ExecuteScalar();

                connection.Close();

                return result;
            }
        }

        public static FoundAthlete getAthleteInfoByToken(string token)
        {
            connection.Open();

            using (NpgsqlCommand cmd = new NpgsqlCommand("\"GetUsernameBasedOnToken\"", connection))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_token", token);
                string result = (string)cmd.ExecuteScalar();
                connection.Close();

                return searchAthleteBasedOnTerm(result)[0];
            }
        }

        public static bool createChallenge(string token, string name, string startdate, string finishdate, string activity_type, string challengetype, int distancetravelled)
        {
            connection.Open();

            using (NpgsqlCommand cmd = new NpgsqlCommand("\"CreateChallenge\"", connection))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_token", token);
                cmd.Parameters.AddWithValue("_name", name);
                cmd.Parameters.AddWithValue("_startDate", startdate);
                cmd.Parameters.AddWithValue("_finishDate", finishdate);
                cmd.Parameters.AddWithValue("_activity_type", activity_type);
                cmd.Parameters.AddWithValue("_challengetype", challengetype);
                cmd.Parameters.AddWithValue("_distancetravelled", distancetravelled);
                bool result = (bool)cmd.ExecuteScalar();
                connection.Close();

                return result;
            }
        }

        public static List<FoundChallenge> getChallenges()
        {
            connection.Open();

            using (NpgsqlCommand cmd = new NpgsqlCommand("\"GetChallenges\"", connection))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var result = cmd.ExecuteReader();

                List<FoundChallenge> foundChallenges = new List<FoundChallenge>();

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

                    DateTime start = DateTime.Parse(attributes[1]);
                    DateTime finish = DateTime.Parse(attributes[2]);
                    int period = Convert.ToInt32((finish - start).TotalDays);

                    foundChallenges.Add(new FoundChallenge(attributes[0], period, attributes[3], attributes[4], int.Parse(attributes[5]), attributes[6]));
                }

                connection.Close();

                return foundChallenges;
            }
        }
    }
}
