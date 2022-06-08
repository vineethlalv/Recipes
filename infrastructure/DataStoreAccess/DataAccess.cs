using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongoDB.Bson;

using recipe_service.Application.Interfaces;

namespace recipe_service.Infrastructure.DataAccess;

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