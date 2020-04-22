using MongoDB.Bson.Serialization;


public class GoogleCrawlerMap
{
    public static void Configure()
    {
        BsonClassMap.RegisterClassMap<Users>(map =>
        {
            map.AutoMap();
            map.SetIgnoreExtraElements(true);
            map.SetIsRootClass(true);
            map.SetIdMember(map.GetMemberMap(c => c.Id));
            //map.MapIdMember(x => x.Id);
        });
    }
}
