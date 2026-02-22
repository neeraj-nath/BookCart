using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using BookCart.Services.Interfaces;
using BookCart.Services.Models;

namespace BookCartWeb.Controllers;

public class CategoryController(ICategoryService service) : Controller
{
    private readonly ICategoryService _service = service;

    public async Task<IActionResult> Index(CancellationToken ct)
    {
        IReadOnlyList<CategoryModel> getCategories = await _service.GetAll(ct);
        return View(getCategories);
    }

    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CategoryModel model, CancellationToken ct)
    {
        //Better to integrate custom validations directly to the model via custom validation attributes. Prefer on SRP for the controller
        //if (int.TryParse(model.Name, out int _))
        //{
        //    ModelState.AddModelError(nameof(model.Name), "Name cannot be a numeric value");
        //}

        if (!ModelState.IsValid) return View();

        _ = await _service.Create(model, ct);

        return RedirectToAction(nameof(Index));
    }
}
