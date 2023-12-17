using Case_Management_System.Models.ServiceRepository;
using Case_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Case_Management_System.Components
{
    public class ServiceListViewComponent:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			ServiceRepository repo = new ServiceRepository();
			List<Service> list = repo.GetAllServices();
			return View(list);
		}
	}
}
