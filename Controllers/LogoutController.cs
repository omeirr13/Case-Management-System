using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Case_Management_System.Models;

namespace Case_Management_System.Controllers
{
    public class LogoutController: Controller
    {
        [HttpGet]
        public ActionResult Logout()
        {
            HttpContext.Response.Cookies.Delete("user_name");
            //HttpContext.Response.Cookies.Delete("user_email");
            HttpContext.Session.Remove("user_email");

            HttpContext.Response.Cookies.Delete("lawyer_name");

            return RedirectToAction("Index", "Home");
        }
    }
}
