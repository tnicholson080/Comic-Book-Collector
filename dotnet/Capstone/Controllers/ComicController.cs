using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.DAO;
using Capstone.Models;
using Capstone.Services;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ComicController : Controller
    {
        private readonly IComicDao _comicDao;
        private readonly ComicVineApiService _cvApi;
        
        public ComicController(IComicDao comicDao, ComicVineApiService cvApi)
        {
            _comicDao = comicDao;
            _cvApi = cvApi;
        }

        [HttpGet("/comics/search/{searchParam}")]
        public IList<Comic> GetSearchedListOfComics(string searchParam)
        {
            return _cvApi.GetComicsByName(searchParam);
            
        }
        
        [HttpGet("/comics/{id}")]
        public Comic GetComicById(int id)
        {
            return _cvApi.GetComicById(id);
        }

        [HttpGet("/collections/{comicCollectionId}/comics")]
        public List<Comic> GetComicsByCollection(int comicCollectionId)
        {
            return _comicDao.GetComicsByCollection(comicCollectionId);

        }

    }
}
