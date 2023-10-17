using E_VotingSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_VotingSystem.Controllers
{
	public class ProfileController : Controller
	{
		public IActionResult Index(ModUser l_ModLoggedInUser )
		{
			return View(l_ModLoggedInUser);
		}
	}
}
