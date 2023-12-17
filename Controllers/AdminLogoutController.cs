using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Case_Management_System.Models;

namespace Case_Management_System.Controllers
{
	public class AdminLogoutController : Controller
	{
		[HttpGet]
		public ActionResult AdminLogout()
		{
			HttpContext.Response.Cookies.Delete("user_name");

			return RedirectToAction("Index", "Home");
		}
	}
}
