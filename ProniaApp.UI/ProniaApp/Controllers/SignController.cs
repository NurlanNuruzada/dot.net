using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pronia.Core.Entities;
using ProniaApp.Utilities;
using ProniaApp.ViewModels;

namespace ProniaApp.Controllers
{

    public class SignController : Controller
    {
        private readonly UserManager<UserApp> _userManager;
        private readonly SignInManager<UserApp> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public SignController(UserManager<UserApp> userManager, SignInManager<UserApp> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVm registerVm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            UserApp userApp = new UserApp
            {
                UserName = registerVm.UserName,
                Email = registerVm.Email,
                FullName = string.Concat(registerVm.FirstName, " ", registerVm.LastName),
            };
            IdentityResult result = await _userManager.CreateAsync(userApp, registerVm.Password);
            if (!result.Succeeded)
            {
                foreach (var message in result.Errors)
                {
                    ModelState.AddModelError("", message.Description);
                }
                return View();
            }
            await _userManager.AddToRoleAsync(userApp,UserRole.Member);
           return RedirectToAction("Index", "Home");

        }
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(LoginVm loginVm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            UserApp user = await _userManager.FindByNameAsync(loginVm.UserName);
            if (user is null)
            {
                ModelState.AddModelError("", "Username or password is incorrect");
                return View();
            }
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, loginVm.Password, loginVm.IsLoggedIn, true);
            if (!result.Succeeded)
            {
                if (result.IsLockedOut)
                {
                    ModelState.AddModelError("", "Due to overtrying your account has been blocked for 5 minutes");
                    return View();
                }
                ModelState.AddModelError("", "Username or password is incorrect");
                return View();
            }
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> LogOut()
        {
                await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
        #region Roles
        //public async Task CreateRole()
        //{
        //    foreach (var role in Enum.GetValues(typeof(UserRole.Roles)))
        //    {
        //        var roleName = role.ToString();
        //        bool isExist = await _roleManager.RoleExistsAsync(roleName);

        //        if (!isExist)
        //        {
        //            object value = await _roleManager.CreateAsync(new IdentityRole { Name ="Admin" });
        //        }
        //    }
        //}

        #endregion
    }
}
