using Microsoft.AspNetCore.Identity;

namespace Petfy.Data.Models
{
    public class AppRole:IdentityRole<int>
    {
        public IEnumerable<AppUserRole> UserRoles { get; set; }
    }
}