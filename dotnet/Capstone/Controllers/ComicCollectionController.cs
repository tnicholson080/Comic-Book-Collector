using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;
using Capstone.DAO;
using Capstone.Models;
using Capstone.Services;
using Microsoft.AspNetCore.Authorization;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ComicCollectionController : Controller
    {
        private readonly IComicCollectionDao _comicCollectionDao;
        private readonly IUserDao _userDao;
        private readonly ComicVineApiService _comicVineApiService;
        private readonly IComicDao _comicDao;

        public ComicCollectionController(IComicCollectionDao comicCollectionDao, IUserDao userDao, ComicVineApiService comicVineApiService, IComicDao comicDao)
        {
            _comicCollectionDao = comicCollectionDao;
            _userDao = userDao;
            _comicVineApiService = comicVineApiService;
            _comicDao = comicDao;
        }

        private User WhoAmI()
        {
            return _userDao.GetUser(int.Parse(User.FindFirst("sub")?.Value));
        }

        [Authorize]
        [HttpGet("/users/{userId}/collections")]
        public IList<ComicCollection> GetComicCollectionsByUserId(int userId)
        {
            if (userId == WhoAmI().UserId)
            {
                return _comicCollectionDao.GetComicCollectionsByUser(userId);
            }
            else return _comicCollectionDao.GetPublicComicCollectionsByUser(userId);
            
        }

        [HttpGet("/collections/{collectionId}")]
        public ComicCollection GetComicCollectionByCollectionId(int collectionId)
        {
            return _comicCollectionDao.GetComicCollection(collectionId);
        }

        [HttpGet("/collections/public")]
        public IList<ComicCollection> GetAllPublicComicCollections()
        {
            return _comicCollectionDao.GetAllPublicComicCollections();
        }

        [HttpPost("/collections")]
        public ActionResult<ComicCollection> CreateNewComicCollection(ComicCollection newComicCollection)
        {
            newComicCollection.userId = WhoAmI().UserId;
            ComicCollection returnComicCollection = _comicCollectionDao.AddComicCollection(newComicCollection);
            return Created($"/collections/{returnComicCollection.id}", returnComicCollection);
        }

        [HttpPost("/collections/{comicCollectionId}")]
        public ActionResult AddComicToComicCollection(int comicCollectionId, Comic comic)
        {
            if (_userDao.CheckEligibility(comicCollectionId, WhoAmI().UserId))
            {



                Comic comicToAdd = _comicDao.GetComicById(comic.id);

                if (comicToAdd == null)
                {
                    comicToAdd = _comicVineApiService.GetComicById(comic.id);
                    _comicDao.AddComic(comicToAdd);
                }

                _comicCollectionDao.AddComicToComicCollection(comicCollectionId, comicToAdd);
            }

            return Ok();
        }

        [HttpDelete("/collections/{comicCollectionId}/delete-comic-from-collection")]
        public ActionResult DeleteComicFromComicCollection(int comicCollectionId, Comic comic)
        {
            User requester = WhoAmI();
            ComicCollection collection = _comicCollectionDao.GetComicCollection(comicCollectionId);

            if (collection.userId == requester.UserId)
            {
                List<int> comicIds = _comicDao.GetComicIdsByCollection(collection.id);

                if (comicIds.Contains(comic.id))
                {
                    _comicCollectionDao.RemoveComicFromComicCollection(collection.id, comic.id);
                    return Ok();
                }
            }
            
            return BadRequest();
        }

        [HttpPut("/collections/{comicCollectionId}")]
        public ActionResult<ComicCollection> UpdateComicCollection(int comicCollectionId, ComicCollection comicCollection)
        {
            User requester = WhoAmI();
            ComicCollection existingComicCollection = _comicCollectionDao.GetComicCollection(comicCollectionId);
            if (existingComicCollection == null)
            {
                return NotFound();
            }

            ComicCollection updatedCollection = null;
            if (existingComicCollection.userId == requester.UserId)
            {
                updatedCollection = _comicCollectionDao.UpdateCollection(comicCollection);
            }

            if (updatedCollection != null)
            {
                return Ok(updatedCollection);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("/collections/{comicCollectionId}")]
        public ActionResult DeleteComicCollection(int comicCollectionId)
        {
            User requester = WhoAmI();
            ComicCollection comicCollectionToDelete = _comicCollectionDao.GetComicCollection(comicCollectionId);
            if (comicCollectionToDelete == null)
            {
                return NotFound();
            }

            bool isSuccessful = false;
            if (comicCollectionToDelete.userId == requester.UserId)
            {
                isSuccessful = _comicCollectionDao.DeleteComicCollection(comicCollectionToDelete.id);
                
            }

            if (isSuccessful)
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("/collections/{comicCollectionId}/toggle-favorite")]
        public ActionResult<ComicCollection> ToggleFavoriteStatus(int comicCollectionId)
        {
            User requester = WhoAmI();
            ComicCollection comicCollection = _comicCollectionDao.GetComicCollection(comicCollectionId);
            List<int> favoritedComicCollectionIds =
                _comicCollectionDao.GetFavoritedCollectionIdsForUser(requester.UserId);

            if (favoritedComicCollectionIds.Contains(comicCollection.id))
            {
                _comicCollectionDao.UnfavoriteCollection(comicCollection.id, requester.UserId);
                comicCollection.isFavorited = false;
            }
            else
            {
                _comicCollectionDao.FavoriteCollection(comicCollection.id, requester.UserId);
                comicCollection.isFavorited = true;
            }

            return Ok(comicCollection);
        }
    }
}
