using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class Blog_controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
