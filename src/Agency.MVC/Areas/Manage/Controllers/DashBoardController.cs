using Agency.Core.Models;
using Agency.MVC.Areas.Manage.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Agency.MVC.Areas.Manage.Controllers
{
    //[Authorize(Roles = "SuperAdmin,Admin")]
    [Area("manage")]
    public class DashBoardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;

        public DashBoardController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(AdminLoginViewModel adminLoginVM)
        {
            if (!ModelState.IsValid) return View(adminLoginVM);
            AppUser admin = null;
            admin = await _userManager.FindByNameAsync(adminLoginVM.Username);
            if (admin is null)
            {
                ModelState.AddModelError("", "Invalid Username or Password");
                return View();
            }
            var result = await _signInManager.PasswordSignInAsync(admin, adminLoginVM.Password, false, false);


            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Invalid Username or Password");
                return View();
            }
            return RedirectToAction("Index", "Dashboard");
        }
        //public async Task<IActionResult> CreateAdmin()
        //{
        //    AppUser admin = new AppUser()
        //    {
        //        FullName = "Tenzile Abdiyeva",
        //        UserName = "Tenzile",

        //    };
        //    var result = await _userManager.CreateAsync(admin, "Admin123@");

        //    return Ok(result);
        //}

        //public async Task<IActionResult> CreateRole()
        //{
        //    IdentityRole role1 = new IdentityRole("SuperAdmin");
        //    IdentityRole role2 = new IdentityRole("Admin");
        //    IdentityRole role3 = new IdentityRole("Editor");
        //    IdentityRole role4 = new IdentityRole("Member");

        //    await _roleManager.CreateAsync(role1);
        //    await _roleManager.CreateAsync(role2);
        //    await _roleManager.CreateAsync(role3);
        //    await _roleManager.CreateAsync(role4);

        //    return Ok("Yarandi");
        //}
        //public async Task<IActionResult> AddRoleAdmin()
        //{
        //    AppUser admin = await _userManager.FindByNameAsync("SuperAdmin");
        //    await _userManager.AddToRoleAsync(admin, "SuperAdmin");
        //    return Ok("Add olundu");

        //}
    }
}
