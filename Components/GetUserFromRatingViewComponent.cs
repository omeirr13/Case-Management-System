using Case_Management_System.Models.ServiceRepository;
using Case_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Case_Management_System.Controllers;
using Case_Management_System.Models.RatingRepository;
using Case_Management_System.Models.LawyerRepository;
using Case_Management_System.Models.UserRepository;

namespace Case_Management_System.Components
{
    public class GetUserFromRatingViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(Rating r)
        {
            UserRepository repo = new UserRepository();
            User u = repo.GetUserOnUserId(r.UserId);

            object ret = u.Name;
            return View(ret);
        }
    }
}
