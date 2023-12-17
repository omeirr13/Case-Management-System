using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Mvc;
using Case_Management_System.Models;
using Case_Management_System.Models.UserRepository;
using Case_Management_System.Models.LawyerRepository;

namespace Case_Management_System.Controllers
{
    public class LoginLawyerController : Controller
    {
        [HttpGet]
        public ActionResult LoginLawyer()
        {
            Console.WriteLine(1);
            if (HttpContext.Request.Cookies["user_name"] == "admin")
            {
                CustomError error = new CustomError { ErrorCode = "403", Error = "Forbidden", Description = "Admin is not allowed to access this page" };
                return RedirectToAction("CustomError", "CustomError", error);
            }
            return View();
        }

        [HttpPost]
        public ActionResult LoginLawyer(string LawyerEmail, string LawyerPassword)
        {
            LawyerRepository repo = new LawyerRepository();
            Lawyer lawyer = repo.GetLawyer(LawyerEmail);

            ModelState.Clear();

            if (lawyer == null)
            {
                ModelState.AddModelError("Email", $"Lawyer with email {LawyerEmail} does not exist");
                return View(lawyer);
            }
            if (lawyer.LawyerPassword.Trim() != LawyerPassword)
            {
                ModelState.AddModelError("Password", $"Invalid Password");
                return View(lawyer);
            }
            if (!HttpContext.Request.Cookies.ContainsKey("lawyer_name"))
            {
                CookieOptions option = new CookieOptions();
                option.Expires = System.DateTime.Now.AddDays(1);

                HttpContext.Response.Cookies.Append("lawyer_name", $"{lawyer.LawyerName}", option);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
