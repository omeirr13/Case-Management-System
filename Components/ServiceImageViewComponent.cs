using Case_Management_System.Models.ServiceRepository;
using Case_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Case_Management_System.Components
{
    public class ServiceImage : ViewComponent
    {
        public IViewComponentResult Invoke(Service ser)
        {
            //ServiceRepository repo = new ServiceRepository();
            //Service s = repo.GetServiceOnServiceId(serviceId);

            //string[] arr = s.ImageUrl.Split("\\");
            //object url = arr[arr.Length - 1];
            return View(ser); 
        }
    }
}
