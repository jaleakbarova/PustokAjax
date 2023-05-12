using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PustoKen.Models;
using PustoKen.ViewModels;

namespace PustoKen.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager, RoleManager<IdentityRole> _roleManager)
        {
            _userManager = _userManager;
            _signInManager = _signInManager;
            _roleManager = _roleManager;
        }
     

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Register(RegisterVM registerVM)
        {

            if (!ModelState.IsValid) return View();
            AppUser newUser = new AppUser()
            {
                FullName=registerVM.FullName,
                UserName=registerVM.UserName,
                Email=registerVM.Email,

            };

            IdentityResult result = await _userManager.CreateAsync(newUser, registerVM.Password);
            return RedirectToAction("Index", "Home");

        }
    }
}
