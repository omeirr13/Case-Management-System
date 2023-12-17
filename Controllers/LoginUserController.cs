using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Mvc;
using Case_Management_System.Models;
using Case_Management_System.Models.UserRepository;

namespace Case_Management_System.Controllers
{
    public class LoginUserController: Controller
	{
		[HttpGet]
		public ActionResult Login()
		{
            if (HttpContext.Request.Cookies["user_name"] == "admin")
            {
                CustomError error = new CustomError { ErrorCode = "403", Error = "Forbidden", Description = "Admin is not allowed to access this page" };
                return RedirectToAction("CustomError", "CustomError", error);
            }
            return View();
		}

		[HttpPost]
		public ActionResult Login(string email, string password)
		{
			UserRepository repo = new UserRepository();
			User user = repo.GetUser(email);
			//var user = context.Users.FirstOrDefault(u => u.Email == email);
			ModelState.Clear();

			if (user == null)
			{
				ModelState.AddModelError("Email", $"User with email {email} does not exist");
				return View(user);
			}
			if (user.Password.Trim() != password)
			{
				ModelState.AddModelError("Password", $"Invalid Password");
				return View(user);
			}
			string data;
			if (!HttpContext.Request.Cookies.ContainsKey("user_name"))
			{
				CookieOptions option = new CookieOptions();
				option.Expires = System.DateTime.Now.AddDays(1);

				HttpContext.Response.Cookies.Append("user_name", $"{user.Name}", option);
				HttpContext.Session.SetString("user_email", user.Email);
				//HttpContext.Response.Cookies.Append("user_email", $"{user.Email}", option);
            }

			return RedirectToAction("Index", "Home");
		}
	}
}
