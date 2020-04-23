

//public class UsersRepository : MongoRepository<IMongoContext, Users>, IUsersRepository
//{
//    public UsersRepository(IMongoContext context, IBaseSessionMongo sessionInfo) : base(context, sessionInfo)
//    {
//    }
//}

public class UsersRepository : BaseRepository<Users>, IUsersRepository
{
    public UsersRepository(IMongoContext context) : base(context)
    {
    }
}





