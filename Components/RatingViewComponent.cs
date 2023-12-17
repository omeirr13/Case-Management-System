using Case_Management_System.Models.ServiceRepository;
using Case_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Case_Management_System.Controllers;
using Case_Management_System.Models.RatingRepository;
using Case_Management_System.Models.LawyerRepository;

namespace Case_Management_System.Components
{
    public class RatingViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(int LawyerId, string UserName)
        {
            RatingRepository repo = new RatingRepository();
            List<Rating> list = repo.GetRatingsOfLawyer(LawyerId);

            LawyerRepository repo2 = new LawyerRepository();
            Lawyer l = repo2.GetLawyerOnId(LawyerId);

            Tuple<List<Rating>, Lawyer> tuple = Tuple.Create(list, l);

            return View(tuple);
        }
    }
}
