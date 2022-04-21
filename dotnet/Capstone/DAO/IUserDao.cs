using Capstone.Models;

namespace Capstone.DAO
{
    public interface IUserDao
    {
        User GetUser(string username);
        User GetUser(int userId);
        User AddUser(string username, string password, string emailAddress);
        bool CheckEligibility(int comicCollectionId, int userId);
    }
}
