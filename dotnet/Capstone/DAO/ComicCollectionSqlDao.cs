using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Capstone.Models;

namespace Capstone.DAO
{
    public class ComicCollectionSqlDao : IComicCollectionDao
    {
        private readonly string _connectionString;

        public ComicCollectionSqlDao(string connString)
        {
            _connectionString = connString;
        }

        public IList<ComicCollection> GetAllPublicComicCollections(User user = null)
        {
            List<ComicCollection> publicCollections = new List<ComicCollection>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT collection_id, collection_name, is_public, user_id, number_of_favorites, description, cover, theme " +
                                                "FROM collections c " +
                                                "WHERE is_public = 1;", conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ComicCollection comicCollection = GetComicCollectionFromReader(reader);
                    publicCollections.Add(comicCollection);
                }

                if (user != null)
                {
                    List<int> favoritedCollections = new List<int>();

                    SqlCommand cmd2 = new SqlCommand("SELECT  collection_id " +
                                                     "FROM collections_favorited " +
                                                     "WHERE user_id = @user_id", conn);
                    cmd.Parameters.AddWithValue("@user_id", user.UserId);

                    SqlDataReader reader2 = cmd2.ExecuteReader();

                    while (reader2.Read())
                    {
                        int favoriteCollectionId = Convert.ToInt32(reader2["collection_id"]);
                        favoritedCollections.Add(favoriteCollectionId);
                    }

                    foreach (ComicCollection publicCollection in publicCollections)
                    {
                        publicCollection.isFavorited = favoritedCollections.Contains(publicCollection.id);
                    }
                }
                
            }
            return publicCollections;
        }

        public IList<ComicCollection> GetComicCollectionsByUser(int userID)
        {
            List<ComicCollection> collections = new List<ComicCollection>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT collection_id, collection_name, is_public, user_id, number_of_favorites, description, cover, theme " +
                                                "FROM collections " +
                                                "WHERE user_id = @user_id", conn);
                cmd.Parameters.AddWithValue("@user_id", userID);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ComicCollection comicCollection = GetComicCollectionFromReader(reader);
                    collections.Add(comicCollection);
                }
            }
            return collections;
        }

        public IList<ComicCollection> GetPublicComicCollectionsByUser(int userID)
        {
            List<ComicCollection> collections = new List<ComicCollection>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT collection_id, collection_name, is_public, user_id, number_of_favorites, description, cover, theme " +
                                                "FROM collections "+
                                                "WHERE user_id = @user_id AND is_public = 1", conn);
                cmd.Parameters.AddWithValue("@user_id", userID);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ComicCollection comicCollection = GetComicCollectionFromReader(reader);
                    collections.Add(comicCollection);
                }
            }
            return collections;
        }

        public ComicCollection GetComicCollectionFromReader(SqlDataReader reader)
        {
            ComicCollection comicCollection = new ComicCollection();
            comicCollection.id = Convert.ToInt32(reader["collection_id"]);
            comicCollection.title = Convert.ToString(reader["collection_name"]);
            comicCollection.userId = Convert.ToInt32(reader["user_id"]);
            comicCollection.description = Convert.ToString(reader["description"]);
            comicCollection.cover = Convert.ToString(reader["cover"]);
            comicCollection.theme = Convert.ToString(reader["theme"]);
            if (Convert.ToInt32(reader["is_public"]) == 1)
            {
                comicCollection.isPublic = true;
            }
            else
            {
                comicCollection.isPublic = false;
            }
            comicCollection.favorites = Convert.ToInt32(reader["number_of_favorites"]);
            
            return comicCollection;
        }
        public ComicCollection GetComicCollection(int comicCollectionId)
        {
            ComicCollection collection = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT collection_id, collection_name, is_public, user_id, number_of_favorites, description, cover, theme " +
                                                        "FROM collections " +
                                                        "WHERE collection_id = @collection_id;", conn);
                cmd.Parameters.AddWithValue("@collection_id", comicCollectionId);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    collection = GetComicCollectionFromReader(reader);
                }
            }
            return collection;
        }
        public ComicCollection AddComicCollection(ComicCollection newComicCollection)
        {
            int intPublic;
            if (newComicCollection.isPublic)
            {
                intPublic = 1;
            }
            else
            {
                intPublic = 0;
            }

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO collections (collection_name, is_public, user_id, favorites, description, cover, theme) " +
                                                "OUTPUT INSERTED.collection_id "+
                                                "VALUES(@collection_name, @is_public, @user_id, @favorites, @description, @cover, @theme)", conn);
                cmd.Parameters.AddWithValue("@collection_name", newComicCollection.title);
                cmd.Parameters.AddWithValue("@is_public", intPublic);
                cmd.Parameters.AddWithValue("@user_id", newComicCollection.userId);
                cmd.Parameters.AddWithValue("@favorites", 0); //All new ComicCollections start with 0 favorites
                cmd.Parameters.AddWithValue("@description", newComicCollection.description);
                cmd.Parameters.AddWithValue("@cover", newComicCollection.cover);
                cmd.Parameters.AddWithValue("@theme", newComicCollection.theme);

                newComicCollection.id = Convert.ToInt32(cmd.ExecuteScalar());
               
                               
            }
             
            
            return newComicCollection;
        }
       
        public bool DeleteComicCollection(int collectionID)
        {
            bool isSuccessful = true;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (TransactionScope transaction = new TransactionScope())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("DELETE " +
                                                        "FROM comic_collection " +
                                                        "WHERE collection_id = @collection_id", conn);
                        cmd.Parameters.AddWithValue("@collection_id", collectionID);

                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand("DELETE " +
                                                        "FROM collection_favorited " +
                                                        "WHERE collection_id = @collection_id", conn);
                        cmd.Parameters.AddWithValue("@collection_id", collectionID);

                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand("DELETE " +
                                             "FROM collections " +
                                             "WHERE collection_id = @collection_id", conn);
                        cmd.Parameters.AddWithValue("@collection_id", collectionID);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        transaction.Dispose();
                        isSuccessful = false;
                    }
                }
            }
            return isSuccessful;
        }
        
        public void AddComicToComicCollection(int collectionId, Comic comic)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {

                conn.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO comic_collection (comic_id, collection_id)"+
                                        "VALUES (@comic_id, @collection_id)", conn);
                cmd.Parameters.AddWithValue("@comic_id", comic.id);
                cmd.Parameters.AddWithValue("@collection_id", collectionId);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    //Should we be doing something with this other than catching it?
                }
                
            }          
        }
        public void RemoveComicFromComicCollection(int collectionId, int comicId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("DELETE FROM comic_collection "+
                                                "WHERE collection_id = @collection_id " +
                                                "AND comic_id = @comic_id", conn);
                cmd.Parameters.AddWithValue("@collection_id", collectionId);
                cmd.Parameters.AddWithValue("@comic_id", comicId);

                cmd.ExecuteNonQuery();
            }
        }

        public void FavoriteCollection(int collectionId, int userId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (TransactionScope transaction = new TransactionScope())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO collection_favorited (collection_id, user_id) " +
                                                        "VALUES(@collection_id, @user_id)", conn);
                        cmd.Parameters.AddWithValue("@collection_id", collectionId);
                        cmd.Parameters.AddWithValue("@user_id", userId);

                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand("UPDATE collections " +
                                             "SET favorites += 1 " +
                                             "WHERE collection_id = @collection_id", conn);
                        cmd.Parameters.AddWithValue("@collection_id", collectionId);

                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        transaction.Dispose();
                    }
                }

            }
        }

        public void UnfavoriteCollection(int collectionId, int userId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (TransactionScope transaction = new TransactionScope())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("DELETE FROM collection_favorited " +
                                                        "WHERE collection_id = @collection_id AND user_id = @user_id", conn);
                        cmd.Parameters.AddWithValue("@collection_id", collectionId);
                        cmd.Parameters.AddWithValue("@user_id", userId);

                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand("UPDATE collections " +
                                             "SET favorites -= 1 " +
                                             "WHERE collection_id = @collection_id", conn);
                        cmd.Parameters.AddWithValue("@collection_id", collectionId);

                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        transaction.Dispose();
                    }
                }
            }
        }

        public List<int> GetFavoritedCollectionIdsForUser(int userId)
        {
            List<int> favoritedCollectionIds = new List<int>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT collection_id " +
                                                "FROM collection_favorited " +
                                                "WHERE user_id = @user_id;", conn);
                cmd.Parameters.AddWithValue("@user_id", userId);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int favoritedCollectionId = Convert.ToInt32(reader["collection_id"]);
                    favoritedCollectionIds.Add(favoritedCollectionId);
                }
            }

            return favoritedCollectionIds;
        }

        public ComicCollection UpdateCollection(ComicCollection updatedCollection)
        {     
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("UPDATE collections " +
                                                "SET collection_name = @collection_name, is_public = @is_public, description = @description, cover = @cover, theme = @theme " +
                                                "OUTPUT inserted.collection_id, inserted.is_public, inserted.user_id, inserted.favorites, inserted.description, inserted.cover, inserted.theme, inserted.collection_name " +
                                                "WHERE collection_id = @collection_id", conn);
                cmd.Parameters.AddWithValue("@collection_name", updatedCollection.title);
                cmd.Parameters.AddWithValue("@is_public", updatedCollection.isPublic);
                cmd.Parameters.AddWithValue("@description", updatedCollection.description);
                cmd.Parameters.AddWithValue("@cover", updatedCollection.cover);
                cmd.Parameters.AddWithValue("@theme", updatedCollection.theme);
                cmd.Parameters.AddWithValue("@collection_id", updatedCollection.id);

                cmd.ExecuteNonQuery();

                updatedCollection = GetComicCollection(updatedCollection.id);
            }

            return updatedCollection;
        }
    }
}
