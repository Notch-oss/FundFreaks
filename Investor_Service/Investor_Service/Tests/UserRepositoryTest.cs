using Investor_Service.InfraSetup;
using Investor_Service.Repository;
using Investor_Service.Models;
using Xunit;

namespace Investor_Service.Tests
{
    [TestCaseOrderer("Test.PriorityOrderer", "Test")]
    public class UserRepositoryTest : IClassFixture<UserDbFixture>
    {
        private readonly IUserRepository repository;

        public UserRepositoryTest(UserDbFixture _fixture)
        {
            repository = new UserRepository(_fixture.context);
        }

        [Fact, TestPriority(1)]
        public void CreateUserShouldReturnUser()
        {
            User user = new User { Id = "Nishant", Name = "Nishant", Contact = "9892134560", /*AddedDate = DateTime.Now*/ };

            var actual = repository.Create(user);

            Assert.NotNull(actual);
            Assert.IsAssignableFrom<User>(actual);
        }

        [Fact, TestPriority(2)]
        public void DeleteUserShouldReturnTrue()
        {
            string userId = "Nishant";

            var actual = repository.Delete(userId);
            Assert.True(actual);
        }

        [Fact, TestPriority(3)]

        public void UpdateUserShouldReturnTrue()
        {
            User user = new User { Id = "Mukesh", Name = "Mukesh", Contact = "9822445566", /*AddedDate = DateTime.Now*/ };

            var actual = repository.Update("Mukesh", user);

            Assert.True(actual);
        }

        [Fact, TestPriority(4)]
        public void GetUserByIdShouldReturnUser()
        {
            string userId = "Mukesh";

            var actual = repository.Get(userId);

            Assert.NotNull(actual);
            Assert.IsAssignableFrom<User>(actual);
        }
    }
}
