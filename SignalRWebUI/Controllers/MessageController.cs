using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
    [AllowAnonymous]
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ClientUserCount()
        {
            return View();
        }
    }
}
