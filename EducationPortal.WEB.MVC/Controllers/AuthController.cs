﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EducationPortal.BLL.Interfaces;
using EducationPortal.WEB.MVC.ViewModels;
using Microsoft.Extensions.Logging;

namespace EducationPortal.WEB.MVC.Controllers
{
    public class AuthController : Controller
    {
        private IAuthService service;
        private ILogger logger;

        public AuthController(IAuthService service, ILogger<AuthController> logger)
        {
            this.service = service;
            this.logger = logger;

        }

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await this.service.Register(model.Login, model.Password);

                if (result.Succeeded)
                {
                    this.logger.LogInformation($"User with name: {model.Login} registered");
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        this.logger.LogError($"Error: {error.Code}. {error.Description}");
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null) => View(new LoginViewModel {ReturnUrl = returnUrl});

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await this.service.Login(model.Login, model.Password, model.RememberMe);
                
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        this.logger.LogInformation($"Login successful. User with name: {model.Login}");
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        this.logger.LogInformation($"Login successful. User with name: {model.Login}");
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    this.logger.LogInformation($"User with name: {model.Login}. Wrong password or username");
                    ModelState.AddModelError(string.Empty, "Wrong password or username");
                }
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            this.logger.LogInformation($"Logout Username: {User.Identity.Name}");
            await this.service.LogOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
