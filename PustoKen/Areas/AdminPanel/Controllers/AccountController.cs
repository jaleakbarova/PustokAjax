using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PustoKen.Models;
using System.Runtime.InteropServices;

namespace PustoKen.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class AccountController : Controller
    {
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;
        readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        //public async Task<IActionResult> Index()
        //{
            //AppUser admin = new AppUser()
            //{
            //    FullName = "Admin",
            //    UserName = "Admin",
            //};

            //var result = await _userManager.CreateAsync(admin,"Admin1234");


            //if (!result.Succeeded)
            //{
            //    foreach(var item in result.Errors)
            //    {
            //        ModelState.AddModelError("", item.Description);
            //    }
            //    return View();
            //}



            //await _roleManager.CreateAsync(new IdentityRole("admin"));
            //await _roleManager.CreateAsync(new IdentityRole("member"));

            //var user = await _userManager.FindByNameAsync("Admin");

            //await _userManager.AddToRoleAsync(user, "admin");
            //await _signInManager.SignInAsync(user, false);

            //return Json("Done");

        //}

    }
}
