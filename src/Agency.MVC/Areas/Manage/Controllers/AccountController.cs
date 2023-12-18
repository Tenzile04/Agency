﻿using Agency.Core.Models;
using Agency.MVC.Areas.Manage.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Agency.MVC.Areas.Manage.Controllers
{
    [Area("manage")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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


        //        @model AdminLoginViewModel
        //<!DOCTYPE html>
        //<html lang = "en" >

        //< head >

        //    < meta charset= "utf-8" >
        //    < meta http-equiv= "X-UA-Compatible" content= "IE=edge" >
        //    < meta name= "viewport" content= "width=device-width, initial-scale=1, shrink-to-fit=no" >
        //    < meta name= "description" content= "" >
        //    < meta name= "author" content= "" >

        //    < title > SB Admin 2 - Login</title>

        //    <!-- Custom fonts for this template-->
        //    <link href = "~/manage/vendor/fontawesome-free/css/all.min.css" rel= "stylesheet" type= "text/css" >
        //    < link href= "https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i"
        //          rel= "stylesheet" >

        //    < !--Custom styles for this template-->
        //    <link href = "~/manage/css/sb-admin-2.min.css" rel= "stylesheet" >

        //</ head >

        //< body class="bg-gradient-primary">

        //    <div class="container">

        //        <!-- Outer Row -->
        //        <div class="row justify-content-center">

        //            <div class="col-xl-10 col-lg-12 col-md-9">

        //                <div class="card o-hidden border-0 shadow-lg my-5">
        //                    <div class="card-body p-0">
        //                        <!-- Nested Row within Card Body -->
        //                        <div class="row">
        //                            <div class="col-lg-6 d-none d-lg-block bg-login-image"></div>
        //                            <div class="col-lg-6">
        //                                <div class="p-5">
        //                                    <div class="text-center">
        //                                        <h1 class="h4 text-gray-900 mb-4">Welcome Back!</h1>
        //                                    </div>
        //                                    <form asp-action="login" asp-controller="account" >
        //                                        <div class="form-group">
        //                                            <input asp-for=Username class="form-control form-control-user"

        //                                                   placeholder="Enter Email Address...">
        //                                        </div>
        //                                        <div class="form-group">
        //                                            <input asp-for=Password class="form-control form-control-user"
        //                                                    placeholder="Password">
        //                                        </div>

        //                                        <button type = "submit" class="btn btn-primary btn-user btn-block">
        //                                            Login
        //                                        </button>
        //                                    </form>

        //                                </div>
        //                            </div>
        //                        </div>
        //                    </div>
        //                </div>

        //            </div>

        //        </div>

        //    </div>

        //    <!-- Bootstrap core JavaScript-->
        //    <script src = "~/manage/vendor/jquery/jquery.min.js" ></ script >
        //    < script src="~/manage/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

        //    <!-- Core plugin JavaScript-->
        //    <script src = "~/manage/vendor/jquery-easing/jquery.easing.min.js" ></ script >

        //    < !--Custom scripts for all pages-->
        //    <script src = "~/manage/js/sb-admin-2.min.js" ></ script >

        //</ body >

        //</ html >
    }
}