using Microsoft.AspNetCore.Identity;
using System.Net.Sockets;

namespace Smartclean.core.Entities
{
    public class AppUser : IdentityUser
    {
        public string? Name { get; set; }
        public string? Vorname { get; set; }
        public Address? Address { get; set; }
    }
}
