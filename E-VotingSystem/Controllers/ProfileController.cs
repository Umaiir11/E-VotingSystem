using E_VotingSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_VotingSystem.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            ModUser l_ModLoggedInUser = new ModUser();
            l_ModLoggedInUser = HttpContext.Session.Get<ModUser>("LoggedinUser")!;
            
            return View(l_ModLoggedInUser);
        }

        [HttpPost]
        public IActionResult CastVote()
        {
            // Handle the voting action here.

            // Redirect to the "Index" action of the "Virus" controller
            return RedirectToAction("Index", "Virus");
        }

        [HttpPost]
        public IActionResult Logout()
        {
            // Perform any necessary logout actions here, such as clearing user data or session.

            // Redirect to the "Index" action of the "Account" controller
            return RedirectToAction("Index", "Account");
        }
    }
}
