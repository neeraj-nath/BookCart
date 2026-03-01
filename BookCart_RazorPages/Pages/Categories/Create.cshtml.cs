using System.Threading;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.RazorPages;

using BookCart.Services.Interfaces;
using BookCart.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookCart_RazorPages.Pages.Categories;

public class CreateModel(ICategoryService categoryService) : PageModel
{
    private readonly ICategoryService _categoryService = categoryService;

    [BindProperty]
    public CategoryModel Category { get; set; } = default!;

    public async Task OnGetAsync()
    {
    }

    public async Task<IActionResult> OnPostAsync(CancellationToken ct)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _ = await _categoryService.Create(Category, ct);
        TempData["success"] = "Category Created Successfully!";
        return RedirectToPage("/Categories/Index");
    }
}
