using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
using System.Net.Http;

namespace Capstone.Services
{
    public class ComicVineApiService
    {
        protected static RestClient Client;
        private const string BaseUrl = "https://comicvine.gamespot.com/api/";
        private const string AuthKeyAndFormat = "/?api_key=6b0eac2431b4ddec1542d526ffdcaefd1b082709&format=json";

        public ComicVineApiService()
        {
            Client = new RestClient(BaseUrl);
        }
        
        public List<Comic> GetComicsByName(string searchParameter)
        {
            List<Comic> comics = new List<Comic>();
            string apiEndPoint = "issues";
            string filter = "&filter=name:";
            searchParameter = searchParameter.Trim();
            if(searchParameter != "")
            {
                filter = "&filter=name:";
            }
            string fullUrl = $"{apiEndPoint}{AuthKeyAndFormat}{filter}{searchParameter}";

            RestRequest request = new RestRequest(fullUrl, Method.Get);
            RestResponse<ComicVineRawData> response = Client.ExecuteAsync<ComicVineRawData>(request).Result;

            if (response.Data != null)
            {
                foreach (Comic rawComic in response.Data.results)
                {
                    comics.Add(GetComicFromResponseData(rawComic));
                }
            }
            
            //right now only returns 100 results if we wanted more we would have to accept a second page
            //param to define the offset
            return comics;
        }

        public Comic GetComicById(int issueId)
        {
            Comic comic = null;
            string apiEndPoint = $"issue/4000-{issueId}";
            string fullUrl = $"{apiEndPoint}{AuthKeyAndFormat}";

            RestRequest request = new RestRequest(fullUrl, Method.Get);
            RestResponse<ComicVineRawDataComicDetails> response = Client.ExecuteAsync<ComicVineRawDataComicDetails>(request).Result;

            if (response.Data != null)
            {
                comic = GetComicFromResponseData(response.Data.results);
            }
            
            return comic; //TODO: improve error handling here - returning a null object instead of throwing an exception feels incorrect
        }
        public Comic GetComicFromResponseData(Comic newComic)
        {
            Comic comic = new Comic
            {
                aliases = newComic.aliases,
                api_detail_url = newComic.api_detail_url,
                cover_date = newComic.cover_date,
                date_added = newComic.date_added,
                date_last_updated = newComic.date_last_updated,
                deck = newComic.deck,
                description = newComic.description,
                has_staff_review = newComic.has_staff_review,
                id = newComic.id,
                image = newComic.image,
                imageThumb_url = newComic.image.thumb_url,
                issue_number = newComic.issue_number,
                name = newComic.name,
                site_detail_url = newComic.site_detail_url,
                store_date = newComic.store_date,
                volume = newComic.volume
            };

            return comic;
        }

       
    }
}
