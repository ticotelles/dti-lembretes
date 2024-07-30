using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using sistema_de_lembretes.Models;


namespace meu_sistema_tarefas.Controllers;

public class MainController : Controller
{
    private readonly ILogger<MainController> _logService;

    public MainController(ILogger<MainController> logService)
    {
        _logService = logService;
    }

    public IActionResult Home()
    {
        return View();
    }

    public IActionResult Terms()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
