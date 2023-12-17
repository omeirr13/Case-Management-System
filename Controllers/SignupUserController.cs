using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Case_Management_System.Models;
using Case_Management_System.Models.UserRepository;

namespace Case_Management_System.Controllers
{
    public class SignupUserController : Controller
	{
		[HttpGet]
		public ActionResult Signup()
		{
            if (HttpContext.Request.Cookies["user_name"] == "admin")
            {
                CustomError error = new CustomError { ErrorCode = "403", Error = "Forbidden", Description = "Admin is not allowed to access this page" };
                return RedirectToAction("CustomError", "CustomError", error);
            }
            return View();
		}

		[HttpPost]
		public ActionResult Signup(User user, string repeatPassword)
		{
			UserRepository repo = new UserRepository();
			
			if (repo.CheckUserExists(user.Email))
			{
				ModelState.AddModelError("Email", "Email already exists");
				return View(user);
			}
			if (user.Password != repeatPassword)
			{
				ModelState.AddModelError("Password", "Password do not match");
				return View(user);
			}
			else
			{
				ModelState.Clear();
			}

			repo.AddUser(user);
			return RedirectToAction("Index", "Home");
		}
	}
}
