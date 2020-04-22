

//public class UsersRepository : MongoRepository<MongoContext, Users>, IUsersRepository
//{

//    public UsersRepository(MongoContext context, IBaseSessionMongo sessionInfo) : base(context, sessionInfo)
//    {
//    }

//}

public class UsersRepository : BaseRepository<Users>, IUsersRepository
{
    public UsersRepository(IMongoContext context) : base(context)
    {
    }

}




