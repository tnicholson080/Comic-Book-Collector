using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAO
{
    public class ComicSqlDao : IComicDao
    {
        private readonly string _connectionString;

        public ComicSqlDao(string connString)
        {
            _connectionString = connString;
        }

        public Comic GetComicById(int id)
        {
            Comic comic = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT id, name, image_thumb_url, cover_date, site_detail_url " +
                                                "FROM comics " +
                                                "WHERE id = @id;", conn);
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    comic = GetComicFromReader(reader);
                }
            }
            return comic;
        }

        public List<Comic> GetComicsByCollection(int comicCollectionId)
        {
            List<Comic> comics = new List<Comic>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                
                SqlCommand cmd = new SqlCommand("SELECT c.id, c.name, c.image_thumb_url, c.cover_date, c.site_detail_url " +
                                                "FROM comics c " +
                                                "JOIN comic_collection cc " +
                                                "ON cc.comic_id = c.id " +
                                                "WHERE cc.collection_id = @collection_id", conn);

                cmd.Parameters.AddWithValue("@collection_id", comicCollectionId);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    comics.Add(GetComicFromReader(reader));
                }

            }
            return comics;
        }

        public List<int> GetComicIdsByCollection(int comicCollectionId)
        {
            List<int> comicIds = new List<int>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT comic_id " +
                                                "FROM comic_collection " +
                                                "WHERE collection_id = @collection_id;", conn);
                cmd.Parameters.AddWithValue("@collection_id", comicCollectionId);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    comicIds.Add(Convert.ToInt32(reader["comic_id"]));
                }
            }

            return comicIds;
        }

        public Comic GetComicFromReader(SqlDataReader reader)
        {
            Comic comic = new Comic
            {
                //api_detail_url = Convert.ToString(reader["api_detail_url"]),
                cover_date = Convert.ToString(reader["cover_date"]),
                //date_added = Convert.ToString(reader["date_added"]),
                //date_last_updated = Convert.ToString(reader["date_last_updated"]),
                //deck = Convert.ToString(reader["deck"]),
                //description = Convert.ToString(reader["description"]),
                //has_staff_review = Convert.ToInt32(reader["has_staff_review"]) == 1,
                id = Convert.ToInt32(reader["id"]),
                imageThumb_url = Convert.ToString(reader["image_thumb_url"]),
                //issue_number = Convert.ToString(reader["issue_number"]),
                name = Convert.ToString(reader["name"]),
                site_detail_url = Convert.ToString(reader["site_detail_url"]),
                //store_date = Convert.ToString(reader["store_date"])
            };

            return comic;
        }

        public void AddComic(Comic comic)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO comics (id, name, image_thumb_url, cover_date, site_detail_url) " +
                                                       "VALUES (@id, @name, @image_thumb_url, @cover_date, @site_data_url) ", conn);
                cmd.Parameters.AddWithValue("@id", comic.id);
                cmd.Parameters.AddWithValue("@name", comic.name);
                cmd.Parameters.AddWithValue("@image_thumb_url", comic.imageThumb_url);
                cmd.Parameters.AddWithValue("@cover_date", comic.cover_date);
                cmd.Parameters.AddWithValue("@site_data_url", comic.api_detail_url);

                cmd.ExecuteNonQuery();
            }

            return;
        }
    }
}
