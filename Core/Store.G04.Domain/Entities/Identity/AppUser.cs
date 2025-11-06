using Microsoft.AspNetCore.Identity;

namespace Store.G04.Domain.Entities.Identity
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public Address Address { get; set; }
    }
}