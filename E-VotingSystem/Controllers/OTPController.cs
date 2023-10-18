using E_VotingSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_VotingSystem.Controllers
{
    public class OTPController : Controller
    {
        public IActionResult Index(ModUser l_ModUser)
        {
            return View(l_ModUser);
        }


        [HttpPost]
        public IActionResult Profile(ModUser l_ModUser)
        {
            // Perform any necessary logout actions here, such as clearing user data or session.

            // Redirect to the "Index" action of the "Account" controller
            return RedirectToAction("Index", "Profile", l_ModUser);
        }


    }
}
