using GoogleCrawler.Models.Interfaces;

namespace GoogleCrawler.Models.Repository
{
    public class UsersRepository : BaseRepository<UsersModel>, IUsersRepository
    {
        public UsersRepository(IMongoContext context) : base(context)
        {
        }
    }
}
