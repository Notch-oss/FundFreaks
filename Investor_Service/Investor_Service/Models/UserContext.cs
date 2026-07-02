using Investor_Service.Models;
using MongoDB.Driver;


namespace Investor_Service.Models
{
    public class UserContext 
    {
        //declare variable to connect to MongoDB database
        private readonly MongoClient _client;
        private readonly IMongoDatabase _database;
        public UserContext(IConfiguration configuration)
        {
            //Initialize MongoClient and Database using connection string and database name from configuration

            _client = new MongoClient(configuration.GetValue<string>("InvestorDatabase:ConnectionString"));
            _database = _client.GetDatabase(configuration.GetValue<string>("InvestorDatabase:DatabaseName"));
            Users = _database.GetCollection<User>(configuration.GetValue<string>("InvestorDatabase:CollectionName"));
        }

        //Define a MongoCollection to represent the Users collection of MongoDB
        public IMongoCollection<User> Users { get; set; }
    }
}
