using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class UserStatsSqlDao : IUserStatsDao
    {
        private readonly string _connectionString;

        public UserStatsSqlDao(string connString)
        {
            _connectionString = connString;
        }

        public UserStats GetUsersStats(int userId)
        {
            UserStats stats = new UserStats();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(collection_id) " +
                                                "FROM collections " +
                                                "WHERE user_id = @user_id", conn);
                cmd.Parameters.AddWithValue("@user_id", userId);
                stats.NumberOfCollections = Convert.ToInt32(cmd.ExecuteScalar());

                cmd = new SqlCommand("SELECT COUNT(id) " +
                                     "FROM comics " +
                                     "LEFT JOIN comic_collection cc " +
                                     "ON cc.comic_id = comics.id " +
                                     "LEFT JOIN collections c " +
                                     "ON c.collection_id = cc.collection_id " +
                                     "WHERE c.user_id = @user_id; ", conn);
                cmd.Parameters.AddWithValue("@user_id", userId);
                stats.NumberOfComics = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return stats;
        }
    }
}
