using Case_Management_System.Models.ServiceRepository;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices.ObjectiveC;

namespace Case_Management_System.Controllers
{
	public class AdminAddServiceController : Controller
	{
		[HttpGet]
		public IActionResult AdminAddService()
		{
			return View();
		}

		[HttpPost]
		public IActionResult AdminAddService(string Title, string Description, IFormFile file)
		{
			string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
			filePath= Path.Combine(filePath, Title);
            filePath += Path.GetExtension(file.FileName);
			////string filePath = Path.Combine(, fileName);

			var stream = new FileStream(filePath, FileMode.Create);
			file.CopyTo(stream);
			stream.Close();

			ServiceRepository repo = new ServiceRepository();
			repo.AddService(Title, Description, $"/{Title}{Path.GetExtension(file.FileName)}");

			object ret = $"Service {Title} added succesfully";
			return View(ret);
		}
	}
}
