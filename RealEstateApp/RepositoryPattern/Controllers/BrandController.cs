using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Interfaces;
using RepositoryPattern.Models;

namespace RepositoryPattern.Controllers
{
    public class BrandController : Controller
    {
        private readonly IGenericRepository<Brand> _brandRepository;

        public BrandController(IGenericRepository<Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<IActionResult> Index()
        {
            var brands = await _brandRepository.GetAllAsync();
            return View(brands);
        }

        public IActionResult AddBrand() => View();

        [HttpPost]
        public async Task<IActionResult> AddBrand(Brand brand)
        {
            if (ModelState.IsValid)
            {
                await _brandRepository.AddAsync(brand);
                return RedirectToAction("Index");
            }
            return View(brand);
        }

        public async Task<IActionResult> EditBrand(int id)
        {
            var brand = await _brandRepository.GetByIdAsync(id);
            if (brand == null)
            {
                return NotFound();
            }
            return View(brand);
        }

        [HttpPost]
        public async Task<IActionResult> EditBrand(Brand brand)
        {
            if (ModelState.IsValid)
            {
                await _brandRepository.UpdateAsync(brand);
                return RedirectToAction("Index");
            }
            return View(brand);
        }

        public async Task<IActionResult> DeleteBrand(int id)
        {
            var brand = await _brandRepository.GetByIdAsync(id);
            if (brand == null)
            {
                return NotFound();
            }
            return View(brand);
        }

        [HttpPost, ActionName("DeleteBrand")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _brandRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
