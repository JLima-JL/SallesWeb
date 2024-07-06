using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            List<Departments> list = new List<Departments>();
            list.Add(new Departments { Id = 1, Name = "Eletronicos" });
            list.Add(new Departments { Id = 2, Name = "Moda" });

            return View(list);
        }
    }
}
