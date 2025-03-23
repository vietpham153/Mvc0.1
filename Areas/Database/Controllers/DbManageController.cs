using App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace App.Areas.Database.Controllers
{
    [Area("Database")]
    [Route("/database-manage/[action]")]
    public class DbManageController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public DbManageController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult DeleteDb()
        {
            return View();
        }
        [TempData]
        public string StatusMessage { get; set; }
        [HttpPost]
        public async Task<IActionResult> DeleteDbAsync()
        {
            var delete = await _appDbContext.Database.EnsureDeletedAsync();
            StatusMessage = delete ? "Xoa thanh cong" : "Khong xoa duoc";

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDb()
        {
            await _appDbContext.Database.MigrateAsync();
            StatusMessage = "Update database thanh cong";

            return RedirectToAction(nameof(Index));
        }
    }
}
