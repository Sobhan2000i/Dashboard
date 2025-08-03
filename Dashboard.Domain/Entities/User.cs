
namespace Dashboard.Domain.Entities
{
    public sealed class User
    {
        public string Id { get; private set; }
        public string? IdentityId { get; private set; }
        public string? UserName { get; private set; }
        public string? Name { get; private set; }
        public DateTime CreatedAtUtc { get; private set; }
        public DateTime? UpdatedAtUtc { get; private set; }

        private User() { }
        public User(string id, string userName, string name)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Id cannot be empty.", nameof(id));

            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentException("Username is required.", nameof(userName));

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required.", nameof(name));

            Id = id;
            UserName = userName;
            Name = name;
            CreatedAtUtc = DateTime.UtcNow;
        }

        public void SetIdentityId(string identityId)
        {
            if (string.IsNullOrWhiteSpace(identityId))
                throw new ArgumentException("IdentityId is required.", nameof(identityId));

            IdentityId = identityId;
            UpdatedAtUtc = DateTime.UtcNow;
        }

        public void ChangeName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty.", nameof(name));

            Name = name;
            UpdatedAtUtc = DateTime.UtcNow;

        }
    }
}
