using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using THLTWeb_2280600147_DOGIAAN.Models;
using THLTWeb_2280600147_DOGIAAN.Repositories;

namespace THLTWeb_2280600147_DOGIAAN.Controllers
{
	public class CategoryController : Controller
	{
		private readonly ICategoryRepository _categoryRepository;

		public CategoryController(ICategoryRepository catetoryRepository)
		{
			_categoryRepository = catetoryRepository;
		}

		public async Task<IActionResult> Index()
		{
			var catetories = await _categoryRepository.GetAllAsync();
			return View(catetories);
		}

		public async Task<IActionResult> Add()
		{
			var categories = await _categoryRepository.GetAllAsync();
			ViewBag.Categories = new SelectList(categories, "Id", "Name");
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Add(Category category)
		{
			if (ModelState.IsValid)
			{
				await _categoryRepository.AddAsync(category);
				return RedirectToAction(nameof(Index));
			}
			var categories = await _categoryRepository.GetAllAsync();
			ViewBag.Categories = new SelectList(categories, "Id", "Name");
			return View(category);
		}

		public async Task<IActionResult> Display(int id)
		{
			var catetory = await _categoryRepository.GetByIdAsync(id);
			if (catetory == null)
			{
				return NotFound();
			}
			return View(catetory);
		}

		public async Task<IActionResult> Update(int id)
		{
			var category = await _categoryRepository.GetByIdAsync(id);
			if (category == null)
			{
				return NotFound();
			}
			var categories = await _categoryRepository.GetAllAsync();
			ViewBag.Categories = new SelectList(categories, "Id", "Name", id);
			return View(category);
		}

		[HttpPost]
		public async Task<IActionResult> Update(int id, Category category)
		{
			if (id != category.Id)
			{
				return NotFound();
			}
			if (ModelState.IsValid)
			{
				await _categoryRepository.UpdateAsync(category);
				return RedirectToAction(nameof(Index));
			}
			return View(category);
		}

		public async Task<IActionResult> Delete(int id)
		{
			var catetory = await _categoryRepository.GetByIdAsync(id);
			if (catetory == null)
			{
				return NotFound();
			}
			return View(catetory);
		}

		[HttpPost, ActionName("DeleteConfirmed")]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			await _categoryRepository.DeleteAsync(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
