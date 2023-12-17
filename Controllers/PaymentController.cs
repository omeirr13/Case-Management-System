using Case_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Case_Management_System.Controllers
{
    public class PaymentController : Controller
    {
        [HttpPost]
        public IActionResult Payment(int LawyerId)
        {
            if (!HttpContext.Request.Cookies.ContainsKey("user_name"))
            {
                return RedirectToAction("Login", "LoginUser");
            }

            object go = LawyerId;
            return View(go);
        }
    }
}
