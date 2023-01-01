using Microsoft.AspNetCore.Identity;

namespace WebTechnologiesProject.Models.ViewModels
{
    public class AuthDetailsViewModel
    { 
        public string Cookie { get; set; }
        public IdentityUser User { get; set; }

    }
}
