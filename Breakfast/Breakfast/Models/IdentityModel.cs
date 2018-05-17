using Microsoft.AspNet.Identity.EntityFramework;

namespace Breakfast.Models
{
    public class AppUser : IdentityUser
    {
        public string address { get; set; }
        public string workAddress { get; set; }
        public string zipcode { get; set; }
    }

    public class AppDbContext : IdentityDbContext<AppUser>
    {
        
        public AppDbContext()
            : base("Default")
        {
        }

    }
}