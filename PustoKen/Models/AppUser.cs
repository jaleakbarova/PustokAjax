using Microsoft.AspNetCore.Identity;

namespace PustoKen.Models
{
    public class AppUser:IdentityUser
    {
        public string FullName { get; set; }
    }
}
