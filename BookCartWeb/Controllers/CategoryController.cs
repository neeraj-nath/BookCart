using BookCart.Services;
using BookCart.Services.Models;

using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

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
}
