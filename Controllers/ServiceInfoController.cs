using Case_Management_System.Models;
using Case_Management_System.Models.LawyerRepository;
using Case_Management_System.Models.ServiceRepository;
using Case_Management_System.Models.UserRepository;
using Microsoft.AspNetCore.Mvc;

namespace Case_Management_System.Controllers
{

    public class ServiceInfoController : Controller
    {
        [HttpGet]
        public IActionResult ServiceInfo()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ServiceInfo(string title)
        {
            Console.WriteLine(title);
            ServiceRepository repo = new ServiceRepository();
            //Service s = repo.GetService(title)
            Service s = repo.GetService(title);

            LawyerRepository repo2 = new LawyerRepository();
            List<Lawyer> list = repo2.GetLawyersBasedOnService(s);

            Tuple<List<Lawyer>, Service> pair = Tuple.Create(list, s);

            return View(pair);
        }
    }
}
