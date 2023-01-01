using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebTechnologiesProject.Models;
using WebTechnologiesProject.Models.ViewModels;

namespace WebTechnologiesProject.Controllers
{
    public class AccountController : Controller
    {
        private SignInManager<IdentityUser> _signInManager;
        private UserManager<IdentityUser> _userManager;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Rgister() => View();

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                IdentityUser newUser = new IdentityUser { UserName = user.UserName, Email = user.Email };
                IdentityResult result = await _userManager.CreateAsync(newUser, user.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }

            return View(user);
        }
        public IActionResult Login(string returnUrl) => View(new LoginViewModel { ReturnURL = returnUrl });

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if (ModelState.IsValid)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(loginVM.UserName, loginVM.Password, false, false);

                if (result.Succeeded)
                {
                    return Redirect("/");
                }

                ModelState.AddModelError("", "Invalid username or password");
            }

            return View(loginVM);
        }


        public async Task<IActionResult> Details()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                IdentityUser user = await _userManager.FindByNameAsync(User.Identity.Name);

                return View(new AuthDetailsViewModel { Cookie = Request.Cookies[".AspNetCore.Identity.Application"], User = user });
            }

            return View(new AuthDetailsViewModel());
        }

        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await _signInManager.SignOutAsync();

            return Redirect(returnUrl);
        }

        [Authorize]
        public string AllRoles() => "All Roles";

        [Authorize(Roles = "Admin")]
        public string AdminOnly() => "Admin Only";

        public string AccessDenied() => "Access Denied";

    }
}
