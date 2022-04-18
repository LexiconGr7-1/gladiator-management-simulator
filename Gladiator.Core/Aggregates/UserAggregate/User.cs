using Gladiator.Core.Aggregates.BaseAggregate;

namespace Gladiator.Core.Aggregates.UserAggregate
{
    public class User : Base
    {
        private User() { }

        public string IdentityId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string EmailAddress { get; private set; }

        public static User CreateUser(
            ulong id,
            string identityId,
            string firstName,
            string lastName,
            string emailAddress)
        {
            return new User()
            {
                Id = id,
                IdentityId = identityId,
                FirstName = firstName,
                LastName = lastName,
                EmailAddress = emailAddress,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
        }


    }
}
