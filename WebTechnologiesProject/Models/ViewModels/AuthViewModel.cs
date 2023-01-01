using Microsoft.AspNetCore.Identity;

namespace WebTechnologiesProject.Models.ViewModels
{
	public class AuthViewModel
	{
        public IdentityRole Auth { get; set; }

        

        public IEnumerable<IdentityUser> Members { get; set; }
        public IEnumerable<IdentityUser> NonMembers { get; set; }

        public string AuthName { get; set; }
        public string[] AddIds { get; set; }
        public string[] DeleteIds { get; set; }
    }
}
