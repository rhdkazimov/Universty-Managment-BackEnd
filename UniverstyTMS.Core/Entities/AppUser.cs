
using Microsoft.AspNetCore.Identity;

namespace UniverstyTMS.Core.Entities
{
    public class AppUser:IdentityUser
    {
        public bool IsAdmin { get; set; }
        public int? TypeId { get; set; }
        public Type Type { get; set; }
    }
}
