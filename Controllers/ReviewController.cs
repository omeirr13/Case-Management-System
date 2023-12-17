using Case_Management_System.Models;
using Case_Management_System.Models.CaseHistoryRepository;
using Case_Management_System.Models.LawyerRepository;
using Case_Management_System.Models.RatingRepository;
using Case_Management_System.Models.ServiceRepository;
using Case_Management_System.Models.UserRepository;
using Microsoft.AspNetCore.Mvc;

namespace Case_Management_System.Controllers
{
    public class ReviewController : Controller
    {
        [HttpGet]
        public IActionResult Review(int LawyerId)
        {
            object ret = LawyerId;
            return View(LawyerId);
        }

        [HttpPost]
        public IActionResult Review(int LawyerId, Rating rating)
        {
            string userEmail = HttpContext.Session.GetString("user_email");


            UserRepository repo = new UserRepository();
            User u = repo.GetUser(userEmail);

            LawyerRepository repo2 = new LawyerRepository();
            Lawyer l = repo2.GetLawyerOnId(LawyerId);

            CaseHistory ch = new CaseHistory();
            rating.LawyerId = ch.LawyerId = l.Id;

            rating.UserId = ch.UserId = u.Id;
            ch.Date = DateTime.Now;

            RatingRepository repo3 = new RatingRepository();
            repo3.AddRating(rating);

            CaseHistoryRepository repo4 = new CaseHistoryRepository();
            repo4.AddCase(ch);

            return RedirectToAction("Index", "Home");
        }
        
    }
}
