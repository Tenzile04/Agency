using Agency.Business.Exceptions;
using Agency.Business.Services.Interfaces;
using Agency.Core.Models;
using Agency.Data.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Agency.MVC.Areas.Manage.Controllers
{
    [Area("manage")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ICategoryService _categoryService;

        public CategoryController(AppDbContext context, ICategoryService categoryService)
        {
            _context = context;
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            var existCategory = await _categoryService.GetAllAsync();
            return View(existCategory);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid) return View();

            await _categoryService.CreateAsync(category);

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            Category existCategory = await _categoryService.GetByIdAsync(id);
            if (existCategory == null) return NotFound();
            return View(existCategory);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Category category)
        {

            if (!ModelState.IsValid) return View();

            await _categoryService.UpdateAsync(category);

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _categoryService.Delete(id);
            }
            catch (InvalidNullReferanceException) { }

            return RedirectToAction("index");
        }
    }
}
