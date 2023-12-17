using Case_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Case_Management_System.Controllers
{
	public class AdminLoginController : Controller
	{
		[HttpGet]
		public ViewResult AdminLogin()
		{
			return View();
		}

		[HttpPost]
		public ActionResult AdminLogin(string email, string password)
		{
			if (email != "admin@gmail.com" || password != "admin")
			{
				ModelState.AddModelError("Email", $"Invalid Credentials!");
				return View();
			}

			CookieOptions option = new CookieOptions();
			HttpContext.Response.Cookies.Append("user_name", "admin", option);
			return RedirectToAction("AdminDashboard", "AdminDashboard");
		}
	}
}
