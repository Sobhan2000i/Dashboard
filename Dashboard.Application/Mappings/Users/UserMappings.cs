
using Dashboard.Application.DTOs.Auth;
using Dashboard.Domain.Entities;


namespace Dashboard.Application.Mappings.Users
{
    public static class UserMappings
    {
        public static User ToEntity(this RegisterUserDto dto)
        {
            return new()
            {
                Id = $"u_{Guid.CreateVersion7()}",
                Name = dto.Name,
                UserName = dto.UserName,
                CreatedAtUtc = DateTime.UtcNow,
            };
        }
    }
}
