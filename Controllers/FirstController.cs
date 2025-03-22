using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class FirstController : Controller
    {
        private readonly ILogger _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ProductService _productService;
        public FirstController(ILogger logger,IWebHostEnvironment evn, ProductService productService)
        {
            _logger = logger;
            _webHostEnvironment = evn;
            _productService = productService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Image()
        {
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Files", "Birds.jpg");
            var bytes = System.IO.File.ReadAllBytes(filePath);
            return File(bytes, "image/jpg");
        }

        public IActionResult Privacy()
        {
            var url = Url.Action("Privacy", "Home");
            return LocalRedirect(url);
        }
        public IActionResult Redirect()
        {
            var paths = "http://google.com";
            return Redirect(paths);
        }
        public IActionResult ViewProduct(int? id)
        {
            var kq = _productService.Where(x => x.Id == id).FirstOrDefault();
            if (kq == null)
            {
                TempData["StatusMessage"] = "Khong tim thay san pham";
                return Redirect(Url.Action("Index", "Home"));
            }
            return View();
            //truyen data qua View thong qua Model
            //return View(kq);

            //Truyen data qua ViewData
            //this.ViewData["product"] = kq;
            //return View("ViewProduct2");

            //Truyen data qua ViewBag
            ViewBag.product = kq;
            return View("ViewProduct3");

            //Truyen du lieu thong qua TempData

        }
    }
}
