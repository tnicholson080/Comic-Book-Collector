using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IComicCollectionDao
    {
        IList<ComicCollection> GetAllPublicComicCollections(User user = null);
        IList<ComicCollection> GetComicCollectionsByUser(int userID);
        IList<ComicCollection> GetPublicComicCollectionsByUser(int userID);
        ComicCollection GetComicCollection(int comicCollectionID);
        ComicCollection AddComicCollection(ComicCollection newComicCollection);
        bool DeleteComicCollection(int collectionID);
        void AddComicToComicCollection(int collectionID, Comic comic); //TODO: modify this method to return the updated ComicCollection
        void RemoveComicFromComicCollection(int collectionId, int comicId); //TODO: modify this method to return the updated ComicCollection
        void FavoriteCollection(int collectionId, int userId); //TODO: modify this method to return the updated ComicCollection
        void UnfavoriteCollection(int collectionId, int userId); //TODO: modify this method to return the updated ComicCollection
        public List<int> GetFavoritedCollectionIdsForUser(int userId);
        ComicCollection UpdateCollection(ComicCollection updatedCollection);

    }
}
