
using Dashboard.Application.DTOs.Auth;
using Dashboard.Domain.Entities;


namespace Dashboard.Application.Mappings.Users
{
    public static class UserMappings
    {
        public static User ToEntity(this RegisterUserDto dto)
        {
            string id = $"u_{Guid.CreateVersion7()}";
            return new User(id , dto.UserName , dto.Name);
        }
    }
}
