using Agency.Business.Exceptions;
using Agency.Business.Services.Implementation;
using Agency.Business.Services.Interfaces;
using Agency.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Agency.MVC.Areas.Manage.Controllers
{
    [Area("manage")]
    public class PortfolioController : Controller
    {
        private readonly IPortfolioService _portfolioService;
        private readonly ICategoryService _categoryService;
        public PortfolioController(IPortfolioService portfolioService,ICategoryService categoryService)
        {
            _portfolioService = portfolioService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            List<Portfolio> portfolios = await _portfolioService.GetAllAsync();

            return View(portfolios);
        }
        [HttpGet]
        public async Task<IActionResult> CreateAsync()
        {
            ViewBag.Categories = await _categoryService.GetAllAsync();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Portfolio portfolio)
        {
            ViewBag.Categories = await _categoryService.GetAllAsync();
            if (!ModelState.IsValid) return View();
            try
            {
                await _portfolioService.CreateAsync(portfolio);
            }
            catch (InvalidNotFoundException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            ViewBag.Categories = await _categoryService.GetAllAsync();

            if (id == null) return NotFound();

            Portfolio portfolio = await _portfolioService.GetByIdAsync(id);

            if (portfolio == null) return NotFound();

            return View(portfolio);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Portfolio portfolio)

        {
            ViewBag.Categories = await _categoryService.GetAllAsync();

            if (!ModelState.IsValid) return View();

            try
            {
                await _portfolioService.UpdateAsync(portfolio);
            }
            catch (InvalidNotFoundException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }

            return RedirectToAction("Index");
        }

        
        public async Task<IActionResult> Delete(int id)
        {
            ViewBag.Categories = await _categoryService.GetAllAsync();

            if (id == null) return NotFound();

            try
            {
                await _portfolioService.Delete(id);
            }
            catch (NullReferenceException)
            {
                return View();

            }
            return Ok();
        }
    }
}
