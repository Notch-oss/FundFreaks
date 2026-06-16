using EntrePreneurServiceAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace EntrePreneurServiceAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _user;

        public UserRepository(IOptions<EntrePreneurDatabaseSetting> entrePreneurDatabaseSetting)
        {
            var client = new MongoClient(entrePreneurDatabaseSetting.Value.ConnectionString);
            var database = client.GetDatabase(entrePreneurDatabaseSetting.Value.DatabaseName);
            _user = database.GetCollection<User>(entrePreneurDatabaseSetting.Value.CollectionName);
        }
        public User Create(User user)
        {
            _user.InsertOneAsync(user);
            return user;
        }

        public bool Delete(string id)
        {
            _user.DeleteOneAsync(user => user.Id == id);
            return true;
        }

        public List<User> Get()
        {
            return _user.Find<User>(u => true).ToList();
        }

        public User Get(string id)
        {
            return _user.Find<User>(u => u.Id == id).FirstOrDefault();
        }

        public bool Update(string id, User user)
        {
            _user.UpdateOneAsync<User>(u => u.Id == id, user.Id);
            return true;
        }

        public User GetByName(string firstname)
        {
            return _user.Find<User>(u => u.FirstName == firstname).FirstOrDefault();
        }

        public User GetByEmail(string email)
        {
            return _user.Find<User>(p => p.Email == email).FirstOrDefault();
        }
    }
}
