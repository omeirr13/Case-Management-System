using Case_Management_System.Models;
using Case_Management_System.Models.ServiceRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Case_Management_System.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if(HttpContext.Request.Cookies["user_name"] == "admin")
            {
                CustomError error = new CustomError { ErrorCode = "403", Error = "Forbidden", Description = "Admin is not allowed to access this page" };
                return RedirectToAction("CustomError","CustomError", error);
            }
            
            return View();
        }

        public ActionResult Contact()
        {
            if (HttpContext.Request.Cookies["user_name"] == "admin")
            {
                CustomError error = new CustomError { ErrorCode = "403", Error = "Forbidden", Description = "Admin is not allowed to access this page" };
                return RedirectToAction("CustomError", "CustomError", error);
            }
            return View();
        }

        public ActionResult Services()
        {
            if (HttpContext.Request.Cookies["user_name"] == "admin")
            {
                CustomError error = new CustomError { ErrorCode = "403", Error = "Forbidden", Description = "Admin is not allowed to access this page" };
                return RedirectToAction("CustomError", "CustomError", error);
            }

            ServiceRepository repo = new ServiceRepository();
            List<Service> list = repo.GetAllServices();
            return View(list);
        }

        public ActionResult About()
        {
            if (HttpContext.Request.Cookies["user_name"] == "admin")
            {
                CustomError  error = new CustomError { ErrorCode = "403", Error = "Forbidden", Description = "Admin is not allowed to access this page" };
                return RedirectToAction("CustomError", "CustomError", error);
            }
            return View();
        }
    }
}
