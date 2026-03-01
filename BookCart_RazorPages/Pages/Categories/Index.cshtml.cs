using System.Threading;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc.RazorPages;

using BookCart.Services.Models;
using BookCart.Services.Interfaces;
using System.Threading.Tasks;

namespace BookCart_RazorPages.Pages.Categories;

public class IndexModel(ICategoryService categoryService) : PageModel
{
    private readonly ICategoryService _categoryService = categoryService;

    public IReadOnlyList<CategoryModel> Categories { get; private set; } = default!;
    public async Task OnGetAsync(CancellationToken ct)
    {
        Categories = await _categoryService.GetAll(ct);
    }
}
