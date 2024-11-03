using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRWebUI.Dtos.IdentityDtos;

namespace SignalRWebUI.Controllers
{
    public class SettingController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public SettingController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditDto userEditDto = new UserEditDto
            {
                Name = value.Name,
                Surname = value.Surname,
                Username = value.UserName,
                Mail = value.Email
            };
            return View(userEditDto);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditDto userEditDto)
        {
            if (userEditDto.Password == userEditDto.ConfirmPassword && userEditDto.Password != null && userEditDto.ConfirmPassword != null)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.Name = userEditDto.Name;
                user.Surname = userEditDto.Surname;
                user.UserName = userEditDto.Username;
                user.Email = userEditDto.Mail;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userEditDto.Password);
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            else
            {
                ModelState.AddModelError("", "Şifreler uyuşmuyor veya geçersiz");
                return View(userEditDto);
            }
            return View();
        }
    }
}
