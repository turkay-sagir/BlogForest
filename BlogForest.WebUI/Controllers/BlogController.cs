using BlogForest.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogForest.WebUI.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult BlogDetail(int id)
        {
            ViewBag.i = id;
            return View();
        }
    }
}
