using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebTechnologiesProject.Models.ViewModels;

namespace WebTechnologiesProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthController : Controller
	{
		private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _authManager;

        public AuthController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> authManager)
        {
            _userManager = userManager;
            _authManager = authManager;
        }

        public IActionResult Index() => View(_authManager.Roles);

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create([MinLength(2), Required] string name)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await _authManager.CreateAsync(new IdentityRole(name));

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View();
        }

        public async Task<IActionResult> Edit(string id)
        {
            IdentityRole auth = await _authManager.FindByIdAsync(id);

            IEnumerable<IdentityUser> members = await _userManager.GetUsersInRoleAsync(auth.Name);
            IEnumerable<IdentityUser> nonMembers = _userManager.Users.ToList().Except(members);

            return View(new AuthViewModel
            {
                Auth = auth,
                NonMembers = nonMembers,
                Members = members
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AuthViewModel authVM)
        {
            IdentityResult result;

            foreach (string id in authVM.AddIds ?? Array.Empty<string>())
            {
                IdentityUser user = await _userManager.FindByIdAsync(id);
                result = await _userManager.AddToRoleAsync(user, authVM.AuthName);
            }

            foreach (string id in authVM.DeleteIds ?? new string[] { })
            {
                IdentityUser user = await _userManager.FindByIdAsync(id);
                result = await _userManager.RemoveFromRoleAsync(user, authVM.AuthName);
            }

            return Redirect(Request.Headers["Referer"].ToString());
        }

        public async Task<IActionResult> Delete(string id)
        {
            IdentityRole role = await _authManager.FindByIdAsync(id);

            await _authManager.DeleteAsync(role);

            return RedirectToAction("Index");
        }

    }
}
