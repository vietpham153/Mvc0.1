using App.Data;
using App.Models.Blog;
using App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace App.Areas.Blog.Controllers
{
    [Area("Blog")]
    [Route("/admin/blog/category/[action]/{id?}")]
    [Authorize(Roles = RoleName.Administrator)]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Category
        public async Task<IActionResult> Index()
        {

            //var items = _context.Categories
            //    .Include(c => c.CategoryChildren)   // <-- Nạp các Category con
            //    .AsEnumerable()
            //    .Where(c => c.ParentCategory == null)
            //    .ToList();

            var qr = (from c in _context.Categories select c)
                .Include(c => c.CategoryChildren)
                .Include(c => c.ParentCategory);

            var categories = (await qr.ToListAsync())
                .Where(c=>c.ParentCategory == null)
                .ToList();


            return View(categories);

        }

        // GET: Admin/Category/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .Include(c => c.ParentCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        public void CreateSelectItems(List<Category> source, List<Category> des, int level)
        {
            string prefix = String.Concat(Enumerable.Repeat("—", level));
            foreach (var item in source)
            {
                //item.Title = prefix + " " + item.Title;
                des.Add(new Category()
                {
                    Id = item.Id,
                    Title = prefix + " " + item.Title
                });
                if ((item.CategoryChildren != null) && (item.CategoryChildren.Count > 0))
                {
                    CreateSelectItems(item.CategoryChildren.ToList(), des, level + 1);
                }
            }
        }

        // GET: Admin/Category/Create
        public async Task<IActionResult> Create()
        {
            //ViewData["ParentId"] = new SelectList(_context.Categories, "Id", "Slug");
            //var listcategory = await _context.Categories.ToListAsync();
            //listcategory.Insert(0, new Category()
            //{
            //    Title = "Không có danh mục cha",
            //    Id = -1
            //});
            var qr = (from c in _context.Categories select c)
               .Include(c => c.CategoryChildren)
               .Include(c => c.ParentCategory);

            var categories = (await qr.ToListAsync())
                .Where(c => c.ParentCategory == null)
                .ToList();
            categories.Insert(0, new Category()
            {
                Id = -1,
                Title = "Không có danh mục cha"
            });

            var items = new List<Category>();
            CreateSelectItems(categories, items, 0);
            var selectList = new SelectList(categories, "Id", "Title");
            ViewData["ParentId"] = selectList;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ParentId,Title,Content,Slug")] Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.ParentId.Value == -1)
                    category.ParentId = null;
                Console.WriteLine($"Entity State: {_context.Entry(category).State}");
                _context.Add(category);
                Console.WriteLine("Đang thêm category...");
                try
                {
                    var changes = await _context.SaveChangesAsync();
                    Console.WriteLine($"Số bản ghi thay đổi: {changes}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi lưu vào database: {ex.Message}");
                }

                return RedirectToAction(nameof(Index));
            }

            // ViewData["ParentId"] = new SelectList(_context.Categories, "Id", "Slug", category.ParentId);
            //var listcategory = await _context.Categories.ToListAsync();
            //listcategory.Insert(0, new Category()
            //{
            //    Title = "Không có danh mục cha",
            //    Id = -1
            //});

            var qr = (from c in _context.Categories select c)
               .Include(c => c.CategoryChildren)
               .Include(c => c.ParentCategory);

            var categories = (await qr.ToListAsync())
                .Where(c => c.ParentCategory == null)
                .ToList();
            categories.Insert(0, new Category()
            {
                Id = -1,
                Title = "Không có danh mục cha"
            });

            var items = new List<Category>();
            CreateSelectItems(categories, items, 0);
            var selectList = new SelectList(categories, "Id", "Title");

            ViewData["ParentId"] = selectList;
            return View(category);
        }

        // GET: Admin/Category/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            var qr = (from c in _context.Categories select c)
               .Include(c => c.CategoryChildren)
               .Include(c => c.ParentCategory);

            var categories = (await qr.ToListAsync())
                .Where(c => c.ParentCategory == null)
                .ToList();
            categories.Insert(0, new Category()
            {
                Id = -1,
                Title = "Không có danh mục cha"
            });

            var items = new List<Category>();
            CreateSelectItems(categories, items, 0);
            var selectList = new SelectList(categories, "Id", "Title");

            ViewData["ParentId"] = selectList;

            return View(category);
        }

        // POST: Admin/Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ParentId,Title,Content,Slug")] Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            bool canUpdate = true;


            if(category.ParentId == category.Id)
            {
                ModelState.AddModelError(string.Empty, "Phai chon danh muc cha khac");
                canUpdate = false;
            }

            //Check muc cha phu hop:
            if(canUpdate && category.ParentId!= null)
            {
                var childCates = (from c in _context.Categories select c)
                    .Include(c => c.CategoryChildren)
                    .Where(c => c.ParentId == category.Id);

                //Func check ID:
                Func<List<Category>, bool> checkId = null;
                checkId = (cates) =>
                {
                    foreach (var cate in cates)
                    {
                        Console.WriteLine(cate.Title);
                        if (cate.Id == category.ParentId)
                        {
                            canUpdate = false;
                            ModelState.AddModelError(string.Empty, "Không thể chọn danh mục con làm cha");
                            return true;
                        }
                        if(cate.CategoryChildren != null)
                        {
                            return checkId(cate.CategoryChildren.ToList());
                        }
                    }
                    return false;
                };
                //End Func
                checkId(childCates.ToList());
            }

            if (ModelState.IsValid && canUpdate)
            {
                try
                {
                    if (category.ParentId == -1)
                    {
                        category.ParentId = null;
                    }
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            var qr = (from c in _context.Categories select c)
               .Include(c => c.CategoryChildren)
               .Include(c => c.ParentCategory);

            var categories = (await qr.ToListAsync())
                .Where(c => c.ParentCategory == null)
                .ToList();
            categories.Insert(0, new Category()
            {
                Id = -1,
                Title = "Không có danh mục cha"
            });

            var items = new List<Category>();
            CreateSelectItems(categories, items, 0);
            var selectList = new SelectList(categories, "Id", "Title");

            ViewData["ParentId"] = selectList;
            return View(category);
        }

        // GET: Admin/Category/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .Include(c => c.ParentCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Admin/Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Categories
                .Include(c=>c.CategoryChildren)
                .FirstOrDefaultAsync(c=>c.Id == id);

            if(category == null)
            {
                return NotFound();
            }
            foreach(var item in category.CategoryChildren)
            {
                item.ParentId = category.ParentId;
            }



            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
