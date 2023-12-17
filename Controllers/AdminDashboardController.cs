using Case_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Case_Management_System.Controllers
{
	public class AdminDashboardController : Controller
	{
        [HttpGet]
		public ActionResult AdminDashboard()
		{
            if (Request.Cookies["user_name"] == null)
            {
                CustomError error = new CustomError { ErrorCode = "403", Error = "Forbidden", Description = "Can't access admin page!" };
                return RedirectToAction("CustomError", "CustomError", error);
                // Cookie exists
            }
            return View();
		}
	}
}
