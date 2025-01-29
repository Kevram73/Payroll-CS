using Microsoft.AspNetCore.Identity;

namespace Payroll.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
