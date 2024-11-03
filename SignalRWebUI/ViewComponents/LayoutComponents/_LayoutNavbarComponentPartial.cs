using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRWebUI.Dtos.IdentityDtos;

namespace SignalRWebUI.ViewComponents.LayoutComponents
{
    public class _LayoutNavbarComponentPartial : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _LayoutNavbarComponentPartial(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            ResultUserDto resultUserDto = new ResultUserDto
            {
                Name = value.Name,
                Surname = value.Surname,
                Username = value.UserName,
                Mail = value.Email
            };
            return View(resultUserDto);
        }
    }
}
