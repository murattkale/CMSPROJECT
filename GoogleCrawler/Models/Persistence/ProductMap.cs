using MongoDB.Bson.Serialization;


namespace GoogleCrawler.Models.Persistence
{
    public class UsersMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<UsersModel>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
                map.MapIdMember(x => x.Id);
            });
        }
    }
}