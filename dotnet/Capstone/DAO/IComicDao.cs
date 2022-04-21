using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IComicDao
    {
        public Comic GetComicById(int comicId);
        public List<Comic> GetComicsByCollection(int collectionId);
        public List<int> GetComicIdsByCollection(int comicCollectionId);
        public void AddComic(Comic comic);
    }
}
