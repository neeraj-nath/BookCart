using System.Threading;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using BookCart.Services.Interfaces;
using BookCart.Services.Models;

namespace BookCart_RazorPages.Pages.Categories;

public class EditModel(ICategoryService categoryService) : PageModel
{
    private readonly ICategoryService _categoryService = categoryService;

    [BindProperty]
    public CategoryModel? Category { get; set; } 
    public async Task<IActionResult> OnGetAsync(int id, CancellationToken ct)
    {
        var category = await _categoryService.GetById(id, ct);

        if (category is null)
        {
            return NotFound();
        }

        Category = category;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(CancellationToken ct)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        await _categoryService.Update(Category!, ct);
        TempData["success"] = "Category Updated Successfully!";
        return RedirectToPage("/Categories/Index");
    }
}
