using MongoDB.Driver;
using MongoDB.Bson;

using recipe_service.Application.DTOs;

namespace recipe_service.Infrastructure.DataAccess;

public partial class DataAccess
{
    public bool IsUserExists(string? userName)
    {
        bool exists = false;

        IMongoDatabase usersDB = dbClient.GetDatabase("users");
        var userColl = usersDB.GetCollection<BsonDocument>("user");
        if(userColl != null)
        {
            exists = userColl.Find(new BsonDocument(new BsonElement("uname", userName))).CountDocuments() > 0;
        }

        return exists;
    }

    public void AddUser(UserModel user)
    {
        IMongoDatabase usersDB = dbClient.GetDatabase("users");
        var userColl = usersDB.GetCollection<BsonDocument>("user");
        BsonDocument userDoc = new BsonDocument();
        userDoc.Add(new BsonElement("uname", user.UserName));
        userDoc.Add(new BsonElement("pwsalt", user.PassWord)); // @TODO: salt pw before saving

        userColl.InsertOne(userDoc);
    }
}