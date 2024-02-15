using Microsoft.AspNetCore.Identity;

namespace TaskList.Domain.Entities
{
    public class User:IdentityUser<Guid>
    {
    }
}
