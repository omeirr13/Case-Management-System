using Case_Management_System.Models;
using Case_Management_System.Models.UserRepository;
using Microsoft.AspNetCore.Mvc;

namespace Case_Management_System.Controllers
{
    public class AdminUserRemoveController : Controller
	{
		[HttpGet]
		public IActionResult AdminUserRemove()
		{
			return View();
		}


		[HttpPost]
		public IActionResult AdminUserRemove(string email)
		{
			UserRepository repo = new UserRepository();

			User u = repo.GetUser(email);
			if(u == null)
			{
				ModelState.AddModelError("Email", $"User with email {email} does not exist");
				return View(u);
			}
			repo.RemoveUser(u);
			object str = $"User with email {email} successfully removed!";
			return View(str);
		}
	}
}
