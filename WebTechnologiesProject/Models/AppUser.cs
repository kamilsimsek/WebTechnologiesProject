using Microsoft.AspNetCore.Identity;

namespace WebTechnologiesProject.Models
{
    public class AppUser:IdentityUser
    {
        public string Occupation { get; set; }
    }
}
