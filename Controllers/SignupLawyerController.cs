using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Case_Management_System.Models;
using Case_Management_System.Models.UserRepository;
using Case_Management_System.Models.ServiceRepository;
using Case_Management_System.Models.LawyerRepository;

namespace Case_Management_System.Controllers
{
    public class SignupLawyerController : Controller
	{
		[HttpGet]
		public ActionResult SignupLawyer()
		{
            if (HttpContext.Request.Cookies["user_name"] == "admin")
            {
                CustomError error = new CustomError { ErrorCode = "403", Error = "Forbidden", Description = "Admin is not allowed to access this page" };
                return RedirectToAction("CustomError", "CustomError", error);
            }

			
            return View();
		}

		[HttpPost]
		public ActionResult SignupLawyer(Lawyer l, string repeatPassword, string service)
		{
			LawyerRepository repo = new LawyerRepository();
			if (repo.CheckLawyerExists(l.LawyerEmail))
			{
				ModelState.AddModelError("Email", "Email already exists");
				return View();
			}
			if (l.LawyerPassword != repeatPassword)
			{
				ModelState.AddModelError("Password", "Password do not match");
				return View();
			}
			else
			{
				ModelState.Clear();
			}

			ServiceRepository repoS = new ServiceRepository();
			Service s = repoS.GetService(service.Trim());

			l.ServiceId = s.Id;
			repo.AddLawyer(l);
			return RedirectToAction("Index", "Home");
		}
	}
}
