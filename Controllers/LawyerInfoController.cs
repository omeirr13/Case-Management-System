using Case_Management_System.Models;
using Case_Management_System.Models.LawyerRepository;
using Case_Management_System.Models.ServiceRepository;
using Case_Management_System.Models.UserRepository;
using Microsoft.AspNetCore.Mvc;

namespace Case_Management_System.Controllers
{
    public class LawyerInfoController : Controller
    {
        [HttpGet]
        public IActionResult LawyerInfo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LawyerInfo(string LawyerEmail)
        {
            LawyerRepository repo = new LawyerRepository();
            Lawyer l = repo.GetLawyer(LawyerEmail);

            ServiceRepository repo2 = new ServiceRepository();
            Service s = repo2.GetServiceOnServiceId(l.ServiceId);

            Tuple<Lawyer, Service> tuple = Tuple.Create(l, s);
            return View(tuple);
        }

    }
}
