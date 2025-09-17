using Microsoft.AspNetCore.Identity;

namespace InevntoryManagementSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }

          
    }
}
