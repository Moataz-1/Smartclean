using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartclean.core.DTO
{
    public record ResetPasswordDTO : LoginDTO
    {
        public string Token { get; set; }
    }
    public record LoginDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public record RegisterDTO : LoginDTO
    {
        public string Name { get; set; }
        public string Vorname { get; set; }
    }
    public record ActiveAcountDTO
    {
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
