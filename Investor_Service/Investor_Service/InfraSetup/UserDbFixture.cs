using Investor_Service.Models;

using MongoDB.Driver;

namespace Investor_Service.InfraSetup
{
    public class UserDbFixture : IDisposable
    {
        private IConfigurationRoot configuration;
        public UserContext context;
        public UserDbFixture()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");

            configuration = builder.Build();
            context = new UserContext(configuration);
            context.Users.DeleteMany(Builders<User>.Filter.Empty);
            context.Users.InsertMany(new List<User>
            {
                new User{ Id="Mukesh", Name="Mukesh",Contact="9812345670" /* AddedDate=DateTime.Now*/},
                new User{ Id="Sachin", Name="Sachin", Contact="8987653412" /*AddedDate=DateTime.Now*/}
            });
        }
        public void Dispose()
        {
            context = null;
        }
    }
}
