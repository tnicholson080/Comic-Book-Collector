using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class OverallStatsSqlDao : IOverallStatsDao
    {
        private readonly string _connectionString;

        public OverallStatsSqlDao(string connString)
        {
            _connectionString = connString;
        }

        public OverallStats GetOverallStats()
        {
            OverallStats stats = new OverallStats();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(user_id) FROM users", conn);
                stats.NumberOfUsers = Convert.ToInt32(cmd.ExecuteScalar());

                cmd = new SqlCommand("SELECT COUNT(collection_id) FROM collections;", conn);
                stats.NumberOfCollections = Convert.ToInt32(cmd.ExecuteScalar());

                cmd = new SqlCommand("SELECT COUNT(id) FROM comics;", conn);
                stats.NumberOfComics = Convert.ToInt32(cmd.ExecuteScalar());


            }
            return stats;
        }
    }
}
