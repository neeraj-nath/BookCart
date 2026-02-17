using BookCart.Data.Entities;
using BookCart.Services;
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
        IReadOnlyList<Category> getCategories = await _service.GetAll(ct);
        return View(getCategories);
    }
}
