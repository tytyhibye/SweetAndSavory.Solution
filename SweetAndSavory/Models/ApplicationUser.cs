using Microsoft.AspNetCore.Identity;

namespace SweetAndSavory.Models
{
    public class ApplicationUser : IdentityUser
    {
      public string Name { get; set; }
    }
}