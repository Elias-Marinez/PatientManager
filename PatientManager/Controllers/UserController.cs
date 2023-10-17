
using Microsoft.AspNetCore.Mvc;
using PatientManager.Core.Application.Interfaces.Services;
using PatientManager.Core.Application.ViewModels.User;
using PatientManager.Core.Application.Helpers;
using PatientManager.Middlewares;

namespace PatientManager.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ValidateUserSession _validator;

        public UserController(IUserService userService, ValidateUserSession validator)
        {
            _userService = userService;
            _validator = validator;
        }

        // GET: UserController
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel vm)
        {
            try
            {
                UserViewModel userVm = await _userService.Login(vm);

                if (userVm != null)
                {
                    HttpContext.Session.Set<UserViewModel>("user", userVm);
                    return RedirectToRoute(new { controller = "Home", action = "Index" });
                }
                else
                {
                    ModelState.AddModelError("LoginValidation", "Nombre de usuario o Contraseña incorrectos");
                }

                return View(vm);
            }
            catch
            {
                return View();
            }
        }
        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("user");
            return RedirectToRoute(new { controller = "User", action = "Login" });
        }

        // GET: UserController
        public async Task<ActionResult> Index()
        {
            if (!_validator.isAdmin())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            return View(await _userService.Get());
        }

        public ActionResult Register()
        {
            if (!_validator.isAdmin())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(UserSaveViewModel vm)
        {
            if (!_validator.isAdmin())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            try
            {
                await _userService.Add(vm);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (!_validator.isAdmin())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            return View(await _userService.GetById(id));
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, UserUpdateViewModel vm)
        {
            if (!_validator.isAdmin())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            try
            {
                await _userService.Update(vm, id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            if (!_validator.isAdmin())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            return View(await _userService.GetById(id));
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, UserUpdateViewModel vm)
        {
            try
            {
                if (!_validator.isAdmin())
                    return RedirectToRoute(new { controller = "Home", action = "Index" });

                await _userService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
