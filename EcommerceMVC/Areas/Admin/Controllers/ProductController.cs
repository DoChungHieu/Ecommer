using EcommerceMVC.Data;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly Hshop2023Context db;

        public ProductController(Hshop2023Context context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
