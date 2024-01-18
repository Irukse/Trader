using Microsoft.AspNetCore.Mvc;

namespace HelpTrader.WebApp.Controllers;


public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}