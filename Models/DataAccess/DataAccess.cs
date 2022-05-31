using MongoDB.Driver;
using MongoDB.Bson;

namespace recipe_service.Models;

public partial class DataAccess : IDataAccess
{
    private IConfiguration _config;
    private MongoClient dbClient;

    public DataAccess(IConfiguration configuration)
    {
        _config = configuration;
        dbClient = new MongoClient(_config["MongoConnStr"]);
    }
}