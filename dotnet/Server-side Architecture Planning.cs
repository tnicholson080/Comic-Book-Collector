//Controllers
    //LoginController
    //ComicCollectionController
    //ComicController
        //Get -> List<Comic> GetComicsByName(string nameSearchParam) -> return ComicVineAPIService.GetComicsByName()
        //Get -> Comic GetComicById(int comicVineId) -> return ComicVineAPIService.GetComicById()
//DAO
    //IUserDAO
        //User GetUser(string username)
        //User AddUser(string username, string password, string role)
    //UserSQLDao : IUserDao
        //Properties
            //private readonly string connectionString
        //Methods
            //User GetUser(string username)
            //User AddUser(string username, string password)
            //User AddUser(string username, string password, string email)
            //User GetUserFromReader(SqlDataReader reader)
    //ICollectionDAO
        //Collection GetCollectionsByUser(string username)
    //CollectionSqlDAO : ICollectionDAO
        //Properties
            //private readonly string connectionString
        //Methods
            //List<Collection> GetCollectionsByUser(string username)
            //List<Collection> GetPublicCollectionsByUser(string username)
            //Collection GetCollectionFromReader(string connectionString)
            //Collection AddCollection(string collectionName)
            //void DeleteCollection(int collectionID)
            //void AddComicToCollection(Comic comic)
            //void RemoveComicFromCollection()
    //IComicDAO
        //public Comic GetComicById(int comicId)
        //public List<Comic> GetComicsByCollection(int collectionId)
        //public Comic GetComicFromReader
        //public bool AddComic
    //ComicSqlDAO : IComicDao
    //IStatsDao
    //StatsSqlDAO
        //int GetNumberOfRegisteredUsers()
        //int TotalComicsInAllCollections()
        //decimal AvgComicsPerCollection()
        //string[] GetTop3PopularPublisher()
        //decimal GetPublisherPercentage()
        //int GetNumberOfCollections()
//Models
    //User
        //ReturnUser
        //LoginResponse
        //LoginUser
        //RegisterUser
    //Collection
        //collectionID
        //collectionName
        //isPublic
        //collectionOwnerUserID
        //comicsInCollection[]
    //Comic
        //comicVineIssueID
        //comicName
        //coverArtURL
        //coverDate
        //wikiPageURL
        //publisher
//Services
    //ComicVineAPIService
        //private string APIKey
        //public List<Comics> GetComicsByName()
        //public Comic GetComicById()