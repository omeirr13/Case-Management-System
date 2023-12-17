using Case_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Case_Management_System.Controllers
{
	public class CustomErrorController : Controller
	{
		public ViewResult CustomError(CustomError e)
		{
			return View("CustomError", e);
		}
	}
}
