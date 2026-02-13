using Microsoft.AspNetCore.Mvc;

namespace BookCartWeb.Controllers;

public class CategoryController : Controller
{

    public IActionResult Index()
    {
        return View();
    }
}
